using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.EntityFrameworkBoard.CodeFirst
{
    public class CFStandard
    {
        public CFStandard()
        {

        }
        public int StandardId { get; set; }
        public string StandardName { get; set; }
        //Collection Navigation property
        public ICollection<CFStudent> Students { get; set; }

        //IEnumerable has one method GetEnumerator() which allows one to read through the values in a collection but not write to it.Most of the complexity of using the enumerator is taken care of for us by the for each statement in C#. IEnumerable has one property: Current, which returns the current element.
        //ICollection implements IEnumerable and adds few additional properties the most use of which is Count.The generic version of ICollection implements the Add() and Remove() methods.
        //IList implements both IEnumerable and ICollection.

        //The ICollection is instantiated as a HashSet in the default constructor.Why is HashSet used? Can i use List or something else?
        //A HashSet<T> is used because it guarantees that two values which are equal to each other (which are equality checked by looking at their GetHashCode and Equals methods) only appear once in the collection.And yes, you can change the concrete type to any type which implements ICollection<T>.
    }
}