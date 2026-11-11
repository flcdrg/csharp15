#!/usr/bin/env -S dotnet --

// begin-snippet: days-array
string[] days = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];
// end-snippet

// begin-snippet: simple-collection-without-arguments
var simpleDayList1 = new List<string>(days.Length);
simpleDayList1.AddRange(days[0..3]);
Console.WriteLine($"Capacity of simpleDayList1: {simpleDayList1.Capacity}, Count: {simpleDayList1.Count}");
// end-snippet

// begin-snippet: simple-collection-without-addrange
List<string> simpleDayList2 = [..days[0..3]];
Console.WriteLine($"Capacity of simpleDayList2: {simpleDayList2.Capacity}, Count: {simpleDayList2.Count}");
// end-snippet

List<string> simpleDayList3 = new List<string>(days.Length);
simpleDayList3.AddRange(days[0..3]);
Console.WriteLine($"Capacity of simpleDayList3: {simpleDayList3.Capacity}, Count: {simpleDayList3.Count}");

// begin-snippet: simple-collection-expression-with-arguments
List<string> dayList = [with(capacity: days.Length), ..days[0..3]];
Console.WriteLine($"Capacity of dayList: {dayList.Capacity}, Count: {dayList.Count}");
// end-snippet

// This is what dotPeek decompiled the above code into when symbols were removed
// begin-snippet: equivalent-collection
List<string> equivalentDayList = new List<string>(days.Length);
equivalentDayList.AddRange((IEnumerable<string>)days[0..3]);
// end-snippet
Console.WriteLine($"Capacity of equivalentDayList: {equivalentDayList.Capacity}, Count: {equivalentDayList.Count}");

// begin-snippet: custom-collection-expression-with-arguments
CustomCollection customCollection = [with(capacity: days.Length, tag: "Weekdays"), ..days];
Console.WriteLine($"Tag of customCollection: {customCollection.Tag}");
// end-snippet

// begin-snippet: custom-collection-class
public class CustomCollection : IEnumerable<string>
{
    private readonly List<string> _items;
    public string Tag { get; init; }

    public CustomCollection(int capacity, string tag)
    {
        _items = new List<string>(capacity);
        Tag = tag;
    }

    public void Add(string item)
    {
        _items.Add(item);
    }

    public void AddRange(IEnumerable<string> items)
    {
        _items.AddRange(items);
    }

    public IEnumerator<string> GetEnumerator() => _items.GetEnumerator();

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
}
// end-snippet
