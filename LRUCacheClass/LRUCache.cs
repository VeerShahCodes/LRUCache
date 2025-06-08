namespace LRUCacheClass
{
    public class LRUCache<TKey, TValue>
    {

        public DoublyLinkedList<KeyValuePair<TKey, TValue>> doublyLinkedList;
        public Dictionary<TKey, DoubleLinkedListNode<KeyValuePair<TKey, TValue>>> hashMap;
        private int maxCount;
        private int count;
        public LRUCache(int maxCount)
        {
            doublyLinkedList = new DoublyLinkedList<KeyValuePair<TKey, TValue>>();
            hashMap = new Dictionary<TKey, DoubleLinkedListNode<KeyValuePair<TKey, TValue>>>();
            this.maxCount = maxCount;
            count = 0;
        }

        public void Put(TKey key, TValue val)
        {
            doublyLinkedList.AddFirst(new KeyValuePair<TKey, TValue>(key, val));
            hashMap[key] = doublyLinkedList.Head;
            count++;
            if(count > maxCount)
            {
                hashMap[doublyLinkedList.Tail.Value.Key] = null;
                doublyLinkedList.RemoveLast();
                
               
            }
        }

        public bool TryGetValue(TKey key, out TValue? val)
        {
            if (hashMap[key] != null)
            {
                doublyLinkedList.Remove(hashMap[key].Value);
                doublyLinkedList.AddFirst(hashMap[key].Value);
                val = hashMap[key].Value.Value;
                return true;
            }

            val = default;
            return false;
        }




        
    }
}
