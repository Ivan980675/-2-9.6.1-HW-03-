
class Program
{
    static List<string> names = new List<string> { "Smith", "Johnson", "Williams", "Brown", "Davis" };

    static event EventHandler<SortEventArgs> SortEvent;

    static void Main(string[] args)
    {
        Console.WriteLine("Enter 1 to sort A-Z, or 2 to sort Z-A:");
        int choice = int.Parse(Console.ReadLine());

        SortEvent?.Invoke(null, new SortEventArgs(choice));

        Console.WriteLine("Sorted names:");
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }

    private static void SortNames(object sender, SortEventArgs e)
    {
        if (e.SortDirection == 1)
        {
            names.Sort();
        }
        else if (e.SortDirection == 2)
        {
            names.Sort((a, b) => b.CompareTo(a));
        }
    }

    private class SortEventArgs : EventArgs
    {
        public int SortDirection { get; }

        public SortEventArgs(int sortDirection)
        {
            SortDirection = sortDirection;
        }
    }

