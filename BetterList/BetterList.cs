using System;
using System.Collections.Generic;
using System.Text;

namespace BetterList
{

    /// <summary>
    /// This is a class that is going to extend and make the built in list in c sharp better. 
    /// 1. Creat basic functionalities. 
    /// </summary>
    public class BetterList<T>
    {

        //Public because this is the only object in the field. 
        public IList<T> _TheList;

        /// <summary>
        /// Construc better list with List li as its defult internal data structure. 
        /// </summary>
        public BetterList()
        {
            this._TheList = new List<T>();
        }

        /// <summary>
        /// Given an IList object and it will bridge it. 
        /// </summary>
        /// <param name="listcore"></param>
        public BetterList(IList<T> listcore)
        {
            this._TheList = listcore;
        }


        /// <summary>
        /// Method is causually tested. 
        /// </summary>
        /// <param name="index"></param>
        /// 
        /// <throw>
        /// IndexOutOfRangeException
        /// </throw>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                return this.indexAt(index);
            }
            set
            {
                this.setIndexAt(index,value);
            }
        }


        /// <summary>
        /// Given a int array index that slice the list into a subtlist. 
        /// </summary>
        /// <param name="array">
        /// An int array that contains all the element at the index you want to get. 
        /// If the arrray has exactly two argement, then it's assuming you are slicing 
        /// the array from the position where the first index starts, inclusive. 
        /// </param>
        /// 
        /// <throw>
        /// IndexOutOfRangeException
        /// Casting exception
        /// ArgumentException
        /// </throw>
        /// <returns>
        /// An object, when getting an element,Type T will be returned, when setting an element, 
        /// method will try to cast it to T. 
        /// </returns>
        public BetterList<T> this[params int[] array]
        {
            get
            {
                IList<T> newlist = new List<T>();

                if (array.Length != 2)
                {
                    foreach (int i in array)
                    {
                        newlist.Add(this[i]);
                    }

                    return new BetterList<T>(newlist);
                }

                int start = array[0], end = array[1],len =_TheList.Count;

                //Make the second index positive

                if (end < 0) end = len-1 + end;
                if (start < 0) start = len - 1 + start;

                if (start<0 ||end < 0 || start > end) throw new ArgumentException();

                for (int i = start; i <= end; i++)
                {
                    newlist.Add(this[i]);
                }

                return new BetterList<T>(newlist);
            }
        }

        
        /// <summary>
        /// 
        /// Give a delegate type that takes in T and return bool, this functio will be used to 
        /// filter out the element that satisfies the condition and return a sublist full of them. 
        /// (The order is preserved)
        /// </summary>
        /// <param name="condition">
        /// A delegate that takes in T and return bool, all elements that is true 
        /// will be in the sub list. 
        /// </param>
        /// <returns>
        /// A betterlist sublist. 
        /// </returns>
        [Obsolete("Note Tested")]
        public BetterList<T> this[Func<T, bool> condition]
        {
            get
            {
                IList<T> newlist = new List<T>();
                foreach (T thing in _TheList)
                {
                    if (condition(thing)) newlist.Add(thing);
                }
                    
                return new BetterList<T>(newlist); 
            }
        }



        /// <summary>
        /// 
        /// This method takes in a delegate that takes in int and return boolean, 
        /// The ints are index in this case, hence it select certain element in an index 
        /// that satifies a certain condition. 
        /// </summary>
        /// <param name="indexcondition">
        /// A func that takes in int and return bool 
        /// </param>
        /// <returns></returns>
        public BetterList<T> this[Func<int, bool> indexcondition]
        {
            get
            {
                IList<T> newlist = new List<T>();
                for (int i = 0; i < _TheList.Count; i++)
                {
                    if (indexcondition(i)) newlist.Add(this[i]);
                }

                return new BetterList<T>(newlist);

            }
        }





        

        /// <summary>
        /// Priavate method that helps with the setter part of indexer. 
        /// </summary>
        /// <param name="i">
        /// A negative number that has abs smaller than the length. 
        /// If the number is bigger than the lengh, the list will be padded with default T. 
        /// If the number is less than zero, it will starts from the back of the array and return 
        /// the corresponding element
        /// </param>
        /// <throw>
        /// IndexOutOfRangeException
        /// </throw>
        /// <returns>
        /// T at the i. 
        /// </returns>
        private T indexAt(int i)
        {

            // The case when it's defintely out of range: 
            if (Math.Abs(i) >= _TheList.Count) throw new IndexOutOfRangeException("Index: "+ i);

            // Counter from tail to head if the index is negative: 
            if (i < 0) i = _TheList.Count-1 + i;
            return _TheList[i];

        }

        /// <summary>
        /// Set the element at index to be a certain element. 
        /// </summary>
        /// <param name="i"></param>
        /// - i is not smaller than the negative of the count, positive 
        /// value of i can be as lar as posible, but the list 
        /// will be padded to that length to accomodate the element. 
        /// <param name="arg"></param>
        private void setIndexAt(int i,T arg)
        {
            //Test if index out of range
            if (i < 0 && Math.Abs(i) > _TheList.Count)
                throw new IndexOutOfRangeException("Index: " + i);

            //Swtich the sign
            if (i < 0) i = _TheList.Count-1 + i;

            //Pad it if the i is larger than the length.
            int len = _TheList.Count;
            if (i >= len)
            {
                for (int j = len; j < i; j++)
                {
                    _TheList.Add(default(T));
                }
                _TheList.Add(arg);
                return;
            }
            _TheList[i] = arg; 
        }



        override
        public String ToString()
        {
            StringBuilder s = new StringBuilder();
            foreach (T stuff in _TheList)
                s.Append(stuff.ToString()+',');
            return "["+s.ToString().Substring(0,s.Length-1)+"]"; 
        }


        /// <summary>
        /// Return the length of the list that in the field of the object. 
        /// </summary>
        /// <returns></returns>
        public int getLength()
        {
            return _TheList.Count;
        }
    }
}
