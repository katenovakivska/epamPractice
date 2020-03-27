
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;
using ArrayList;

namespace TestArrayList
{
    public class TestMyArrayList
    {
        [Fact]
        public void Indexator_GetValueOfElement_ValueAtIndexEqualToValue()
        {
            //arrenge
            var array = new int[3] { 1, 2, 3 };
            MyArrayList<int> arrayList = new MyArrayList<int>(array, -2);

            //act
            var firstElement = array[arrayList.LowerBound];
            var lastElement = array[arrayList.LowerBound + arrayList.Capacity - 1];

            //assert
            Assert.Equal(1, firstElement);
            Assert.Equal(3, lastElement);
        }

        [Fact]
        public void Indexator_GetElementOnIndexOutOfRange_ThrowsIndexOutOfRangeException()
        {
            //arrenge
            var array = new int[3] { 1, 2, 3 };
            MyArrayList<int> arrayList = new MyArrayList<int>(array);
            int element;

            //act
            Action action = () => { element = arrayList[-3]; };

            //assert
            Assert.Throws<IndexOutOfRangeException>(action);
        }

        [Fact]
        public void Indexator_SetValueToElement_ValueAtIndexEqualToValue()
        {
            //arrenge
            MyArrayList<int> array = new MyArrayList<int>(-5, 10);

            //act
            array[-1] = 1;

            //assert
            Assert.Equal(1, array[-1]);
        }

        [Fact]
        public void Indexator_GetElementWithIndexOutOfRange_ThrowsIndexOutOfRangeException()
        {
            //arrenge
            MyArrayList<int> array = new MyArrayList<int>(-5, 10);

            //act
            Action action = () => { array[array.LowerBound - 1] = 1; };

            //assert
            Assert.Throws<IndexOutOfRangeException>(action);
        }

        [Fact]
        public void GetEnumerator_IEnumerableGetEnumeratorForArrayList_EnumeratorNotEqualNull()
        {
            //arrenge
            MyArrayList<int> array = new MyArrayList<int>(new int[3] { 1, 2, 3 });

            //act
            IEnumerator enumerator = ((IEnumerable)array).GetEnumerator();

            //assert
            Assert.NotNull(enumerator);
        }

        [Fact]
        public void GetEnumerator_GetEnumeratorForArrayList_EnumeratorNotEqualNull()
        {
            //arrenge
            MyArrayList<int> array = new MyArrayList<int>(new int[3] { 1, 2, 3 });

            //act
            var enumerator = array.GetEnumerator();

            //assert
            Assert.NotNull(enumerator);
        }

        [Fact]
        public void MyArrayList_CreateObject_ObjectIsNotNull()
        {
            //arrenge
            MyArrayList<int> array;

            //act
            array = new MyArrayList<int>();

            //assert
            Assert.NotNull(array);
        }

        [Fact]
        public void MyArrayList_CreateObjectWithValueLowerBondAndCapacity_ObjectIsNotNull()
        {
            //arrenge
            MyArrayList<int> array;

            //act
            array = new MyArrayList<int>(-2, 15);

            //assert
            Assert.NotNull(array);
        }

        [Fact]
        public void MyArrayList_CreateObjectWithCapacitySmallerThenOne_ThrowsArgumentException()
        {
            //arrenge
            MyArrayList<int> array;

            //act
            Action action = () => { array = new MyArrayList<int>(-2, 0); };

            //assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void MyArrayList_CreateObjectWithArray_ObjectIsNotNull()
        {
            //arrenge
            MyArrayList<int> newArray;
            int[] array = new int[3] { 2, 1, 4 };

            //act
            newArray = new MyArrayList<int>(array);

            //assert
            Assert.NotNull(newArray);
        }

        [Fact]
        public void MyArrayList_CreateObjectWithArrayLengthSmallerThenOne_ThrowsArgumentException()
        {
            //arrenge
            MyArrayList<int> newArray;
            int[] array = new int[0];

            //act
            Action action = () => { newArray = new MyArrayList<int>(array); };

            //assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void MyArrayList_CreateObjectWithArrayAndLowerBound_ObjectIsNotNull()
        {
            //arrenge
            MyArrayList<int> array;

            //act
            array = new MyArrayList<int>(new int[3] { 2, 1, 4 }, 2);

            //assert
            Assert.NotNull(array);
        }

        [Fact]
        public void MyArrayList_CreateObjectWithArrayAndLowerBound_ThrowsArgumentException()
        {
            //arrenge
            MyArrayList<int> newArray;
            int[] array = new int[0];

            //act
            Action action = () => { newArray = new MyArrayList<int>(array, 2); };

            //assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void MyArrayList_CreateObjectWithMyArrayList_ObjectIsNotNull()
        {
            //arrenge
            MyArrayList<int> array = new MyArrayList<int>(new int[] { 1, 1, 1});

            //act
            var newArray = new MyArrayList<int>(array);

            //assert
            Assert.NotNull(newArray);
        }

        [Fact]
        public void MyArrayList_CreateObjectWithMyArrayListCapacitySmallerThenOne_ThrowsArgumentExceptio()
        {
            //arrenge
            MyArrayList<int> newArray;
            int[] array = new int[0];

            //act
            Action action = () => { newArray = new MyArrayList<int>(new MyArrayList<int>(array)); };

            //assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void CopyTo_CopyGenericArray_NewArrayEqualToCopied()
        {
            //arrenge
            MyArrayList<int> array = new MyArrayList<int>(new int[3] { 1, 1, 1 });
            int[] newArray = new int[3];

            //act
            array.CopyTo(newArray);

            //assert
            Assert.Equal(array,newArray);
        }

        [Fact]
        public void CopyTo_CopyGenericArrayWithBiggerCapacityThanLowerBound_ThrowsArgumentException()
        {
            //arrenge
            MyArrayList<int> arrayList = new MyArrayList<int>(-1, 3);
            var array = new int[] { 1, 1 };

            //act
            Action action = () => { arrayList.CopyTo(array); };

            //assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void CopyTo_CopyMyArrayList_NewArrayEqualToCopied()
        {
            //arrenge
            MyArrayList<int> array = new MyArrayList<int>(new int[3] { 1, 1, 1 });
            MyArrayList<int> newArray = new MyArrayList<int>(0, 3);

            //act
            array.CopyTo(newArray);

            //assert
            Assert.Equal(array, newArray);
        }

        [Fact]
        public void CopyTo_CopyMyArrayListWithSmallerCapacity_ThrowsArgumentException()
        {
            //arrenge
            MyArrayList<int> array = new MyArrayList<int>(new int[2] { 1, 1 });
            MyArrayList<int> newArray = new MyArrayList<int>(0, 3);

            //act
            Action action = () => { newArray.CopyTo(array); };

            //assert
            Assert.Throws<ArgumentException>(action);
        }


    }
}