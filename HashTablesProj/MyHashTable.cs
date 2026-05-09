namespace HashTablesProj;

public class MyHashTable<TKey, TValue> where TKey : notnull
{
    private class Entry
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public Entry Next { get; set; }
    }

    private Entry[] buckets;
    private const int Capacity = 16;
    public int Count { get; private set; }

    public MyHashTable()
    {
        buckets = new Entry[Capacity];
    }

    public void Add(TKey key, TValue value)
    {
        int index = GetIndex(key);
        var entry = buckets[index];

        while (entry != null)
        {
            if (entry.Key.Equals(key))
                throw new ArgumentException("Նման բանալիով տարր արդեն գոյություն ունի:");
            entry = entry.Next;
        }

        var newEntry = new Entry
        {
            Key = key,
            Value = value,
            Next = buckets[index]
        };

        buckets[index] = newEntry;
        Count++;
    }

    public TValue Get(TKey key)
    {
        int index = GetIndex(key);
        var entry = buckets[index];

        while (entry != null)
        {
            if (entry.Key.Equals(key)) return entry.Value;
            entry = entry.Next;
        }

        throw new KeyNotFoundException("Բանալին չի գտնվել:");
    }

    public bool ContainsKey(TKey key)
    {
        int index = GetIndex(key);
        var entry = buckets[index];

        while (entry != null)
        {
            if (entry.Key.Equals(key)) return true;
            entry = entry.Next;
        }

        return false;
    }

    private int GetIndex(TKey key)
    {
        string keyString = key.ToString() ?? string.Empty;
        int hash = FoldingHash(keyString);
        return Math.Abs(hash % Capacity);
    }

    private static int FoldingHash(string input)
    {
        int hashValue = 0;
        int startIndex = 0;
        int currentFourBytes;

        do
        {
            currentFourBytes = GetNextBytes(startIndex, input);
            unchecked { hashValue += currentFourBytes; }
            startIndex += 4;
        } while (currentFourBytes != 0);

        return hashValue;
    }

    private static int GetNextBytes(int startIndex, string str)
    {
        int currentFourBytes = 0;
        currentFourBytes += GetByte(str, startIndex);
        currentFourBytes += GetByte(str, startIndex + 1) << 8;
        currentFourBytes += GetByte(str, startIndex + 2) << 16;
        currentFourBytes += GetByte(str, startIndex + 3) << 24;
        return currentFourBytes;
    }

    private static int GetByte(string str, int index)
    {
        return index < str.Length ? (int)str[index] : 0;
    }
}