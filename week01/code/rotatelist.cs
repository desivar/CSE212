using System.Collections.Generic;

namespace MyNamespace
{
    public class MyClass
    {
        public List<int> RotateListRight(List<int> data, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                int first = data[0];
                data.RemoveAt(0);
                data.Add(first);
            }
            return data;
        }
    }
}

//use the following code to test the RotateListRight method
//var data = new List<int> { 1, 2, 3, 4, 5 };
//var amount = 2;
//var myClass = new MyClass();
//var result = myClass.RotateListRight(data, amount);
//Console.WriteLine(string.Join(", ", result)); // 4, 5, 1, 2, 3
//amount = 3;
//result = myClass.RotateListRight(data, amount);
//Console.WriteLine(string.Join(", ", result)); // 2, 3, 4, 5, 1
//amount = 4;