using LRUCacheClass;
namespace LRUCache
{
    public class UnitTest1
    {
        DoublyLinkedList<int> doublyLinkedList = new DoublyLinkedList<int>();

        [Fact]
        public void TestPut()
        {
            LRUCache<int, int> lruCache = new LRUCache<int, int>(3);
            lruCache.Put(0, 1);
            lruCache.Put(1, 2);

            
            int x = 1;
            Assert.True(lruCache.TryGetValue(0, out x));

            

        }

        [Fact]
        public void TestRemoveWhenTooMuch()
        {
            LRUCache<int, int?> lruCache = new LRUCache<int, int?>(3);
            lruCache.Put(0, 1);
            lruCache.Put(1, 2);
            lruCache.Put(2, 3);
            lruCache.Put(3, null);
            lruCache.Put(4, 5);
            int? x = null;
            Assert.True(lruCache.TryGetValue(3, out x));
        }


    }
}