using System;

namespace Reflection
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ReviewCommentAttribute : Attribute
    {
        public string Description { get; set; }
        public string VersionNumber { get; set; }
        public string ReviewerId { get; set; }
        
        public ReviewCommentAttribute(string desc, string ver)
        {
            Description = desc;
            VersionNumber = ver;
        }
    }
        
    [ReviewComment("Check it out", "3.0")]
    class MyClass { }   
  
    public class Program
    {
        static void Main()
        {
            MyClass mc = new MyClass();         // Create an instance of the class.
            Type t = mc.GetType();              // Get the Type object from the instance.
            bool isDefined = t.IsDefined(typeof(ReviewCommentAttribute), false);     // Check the Type for the attribute.

            if (isDefined)
            Console.WriteLine("ReviewComment is applied to type {0}", t.Name);

            Console.ReadLine();

        }
     }

}

