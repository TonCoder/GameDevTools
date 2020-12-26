using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AngryLab
{
    [Serializable]
    public class PoolCollection
    {
        public string _Name;
        public bool ActiveFirstItem;
        public int InstantiateQty;
        [Tooltip("Parent transform is not required")]
        public Transform ParentTransform;
        public List<GameObject> items = new List<GameObject>();
    }
}

namespace AngryLab
{
    public class SimplePoolManager : MonoBehaviour
    {
        public static SimplePoolManager instance;

        [SerializeField] private List<PoolCollection> collection = new List<PoolCollection>();

        private Dictionary<string, PoolCollection> _instantiatedList = new Dictionary<string, PoolCollection>();

        //****************************
        // Initiations
        //****************************
        void Awake()
        {
            Singleton();
            InstantatePoolGameObjects();
        }

        void InstantatePoolGameObjects()
        {
            var newlist = new List<GameObject>();

            foreach (PoolCollection poolCollection in collection)
            {
                foreach (GameObject poolItem in poolCollection.items)
                {
                    for (int i = 0; i < poolCollection.InstantiateQty; i++)
                    {
                        GameObject instantiatedGo = poolCollection.ParentTransform != null ?
                            Instantiate(poolItem, transform.position, Quaternion.identity, poolCollection.ParentTransform) :
                            Instantiate(poolItem, transform.position, Quaternion.identity);
                        instantiatedGo.name = instantiatedGo.name.Replace("(Clone)", "");
                        instantiatedGo.SetActive(false);
                        instantiatedGo.transform.ResetTransform();
                        newlist.Add(instantiatedGo);
                    }
                }

                AddToInstantiatedList(poolCollection, newlist);
                newlist.Clear();
            }

            ActivateFirstItem();
        }

        void ActivateFirstItem()
        {
            foreach (PoolCollection poolCollection in collection)
            {
                if (poolCollection.ActiveFirstItem)
                {
                    _instantiatedList[poolCollection._Name].items.FirstOrDefault().SetActive(true);
                }
            }
        }

        //****************************
        // Set Actions
        //****************************
        internal void SetNewCollectionParent(string poolName, Transform newParent)
        {
            if (DoesPoolExist(poolName))
            {
                _instantiatedList[poolName].items.ForEach(x =>
                {
                    x.transform.parent = newParent;
                    x.transform.ResetTransform();
                });
            }
        }

        //****************************
        // Get Actions
        //****************************
        internal GameObject GetSpecificPoolItemInCollection(string poolName, int index)
        {
            if (!DoesPoolExist(poolName))
            {
                return null;
            }

            return _instantiatedList[poolName].items[index];
        }

        internal void GetSpecificPoolItemInCollection(string poolName, int index, Action<GameObject> callback)
        {
            if (!DoesPoolExist(poolName))
            {
                return;
            }

            callback(_instantiatedList[poolName].items[index]);
        }

        internal GameObject GetSpecificPoolItemInCollection(string poolName, GameObject item)
        {
            if (!DoesPoolExist(poolName))
            {
                Debug.Log(string.Format("The pool: {0} does not exist", poolName));
                return null;
            }

            GameObject go = _instantiatedList[poolName].items.FirstOrDefault(x => x.name.Equals(item.name));
            if (go == null)
            {
                Debug.Log(string.Format("The item passed: {0}, does not exist in the pool: {1}", item.name, poolName));
            }
            return go;
        }

        internal GameObject GetNextAvailablePoolItem(string nameOfPool)
        {
            if (!DoesPoolExist(nameOfPool))
            {
                return null;
            }

            GameObject go = null;
            foreach (var item in _instantiatedList[nameOfPool].items)
            {
                if (!item.activeSelf)
                {
                    go = item;
                    break;
                }
            } 

            if (go == null)
            {
                AddOverflowToCurrentPoolList(nameOfPool);
                return GetNextAvailablePoolItem(nameOfPool);
            }

            return go;
        }

        internal GameObject GetRandomPoolItem(string nameOfPool)
        {
            if (!DoesPoolExist(nameOfPool))
            {
                return null;
            }

            GameObject go = _instantiatedList[nameOfPool].items.Where(itm => !itm.activeSelf).ToList()[UnityEngine.Random.Range(0, _instantiatedList[nameOfPool].items.Count)];
            if (go == null)
            {
                AddOverflowToCurrentPoolList(nameOfPool);
                go = _instantiatedList[nameOfPool].items.Where(itm => !itm.activeSelf).ToList()[UnityEngine.Random.Range(0, _instantiatedList[nameOfPool].items.Count)];
            }

            go.SetActive(true);
            return go;
        }

        internal List<GameObject> GetAllItemInACategory(string nameOfPool)
        {
            if (!DoesPoolExist(nameOfPool))
            {
                return null;
            }
            return _instantiatedList[nameOfPool].items;
        }

        internal List<GameObject> GetAllActiveCategoryItem(string nameOfPool)
        {
            if (!DoesPoolExist(nameOfPool))
            {
                return null;
            }
            return _instantiatedList[nameOfPool].items.Where(x => x.activeSelf).ToList();
        }

        internal Transform GetPoolItemParentTransform(string nameOfPool)
        {
            if (!DoesPoolExist(nameOfPool))
            {
                return null;
            }

            return _instantiatedList[nameOfPool].ParentTransform;
        }

        internal bool DoesPoolExist(string nameOfPool)
        {
            return _instantiatedList.ContainsKey(nameOfPool);
        }

        internal bool DoesPoolItemExist(GameObject item)
        {
            bool itemFound = false;
            foreach (var list in _instantiatedList)
            {
                itemFound = list.Value.items.Contains(item);
            }

            return itemFound;
        }

        //****************************
        // Add to pool Actions
        //****************************

        ///<sumarry>
        /// This function does not permanently save the item it adds, it only adds it for run time
        ///</sumarry>
        internal void AddNewItemToCollection(List<PoolCollection> newItemCol)
        {
            foreach (PoolCollection obj in newItemCol)
            {
                if (collection.Any(x => x._Name == obj._Name))
                {
                    collection.FirstOrDefault(x => x._Name == obj._Name).items.Add(obj.items.FirstOrDefault());
                }
                else
                {
                    collection.Add(obj);
                }
            }

            InstantatePoolGameObjects();
        }

        void AddToInstantiatedList(PoolCollection poolObj, List<GameObject> items)
        {
            if (DoesPoolExist(name))
            {
                items.ForEach(_instantiatedList[poolObj._Name].items.Add);
            }
            else
            {
                _instantiatedList.Add(poolObj._Name, new PoolCollection() { ParentTransform = poolObj.ParentTransform, items = new List<GameObject>(items) }); ;
            }
        }

        void AddOverflowToCurrentPoolList(string nameOfPool)
        {
            Debug.Log(string.Format("Added extra items to : {0}, considder increasing the Qty to create in the pool", nameOfPool));

            var currentPoolDetails = collection.FirstOrDefault(x => x._Name == nameOfPool);
            int currentPoolQty = currentPoolDetails.InstantiateQty;
            currentPoolDetails.InstantiateQty += currentPoolQty;

            for (int i = 0; i < currentPoolQty; i++)
            {
                foreach (var item in currentPoolDetails.items)
                {
                    GameObject instantiatedGo = currentPoolDetails.ParentTransform != null ?
                        Instantiate(item, transform.position, Quaternion.identity, currentPoolDetails.ParentTransform) :
                        Instantiate(item, transform.position, Quaternion.identity);
                    instantiatedGo.SetActive(false);
                    instantiatedGo.transform.ResetTransform();

                    _instantiatedList[nameOfPool].items.Add(instantiatedGo);
                }
            }

        }

        //****************************
        // Disable Actions
        //****************************
        internal void DisablePoolObject(string nameOfPool, Transform poolObjectTransform)
        {
            int indx = _instantiatedList[nameOfPool].items.IndexOf(poolObjectTransform.gameObject);
            if (indx < 0)
            {
                Debug.Log(string.Format("Object {0}. Doesnt exist in the specified Poool: {1}", poolObjectTransform.name, nameOfPool));
            }
            _instantiatedList[nameOfPool].items[indx].SetActive(false);
        }

        internal void DisablePoolObject(Transform poolObjectTransform)
        {
            foreach (var list in _instantiatedList)
            {
                int indx = list.Value.items.IndexOf(poolObjectTransform.gameObject);
                if (indx > 0)
                {
                    list.Value.items[indx].SetActive(false);
                }
            }
        }

        internal bool DisablePoolObject(GameObject poolObject)
        {
            foreach (var list in _instantiatedList)
            {
                int indx = list.Value.items.IndexOf(poolObject);
                if (indx > 0)
                {
                    list.Value.items[indx].SetActive(false);
                    list.Value.items[indx].transform.parent = list.Value.ParentTransform;
                    return true;
                }
            }

            return false;
        }

        internal void DisableAllPoolObjects()
        {
            foreach (var list in _instantiatedList)
            {
                try
                {
                    list.Value.items.FindAll(x => x.activeSelf).ForEach(x => x.SetActive(false));
                }
                catch (Exception ex)
                {
                    Debug.Log("Error: " + ex.Message);
                    Debug.Break();
                }
            }
        }

        internal void DisableAllPoolObjectByCategory(string poolName)
        {
            if (!DoesPoolExist(poolName))
            {
                return;
            }
            _instantiatedList[poolName].items.FindAll(x => x.activeSelf).ForEach(x => x.SetActive(false));
        }

        void Singleton()
        {
            if (instance == null || instance != this)
            {
                instance = this;
            }
            else if (instance == this)
            {
                Destroy(gameObject);
            }
        }
    }
}