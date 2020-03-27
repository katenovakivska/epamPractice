
using System;
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
        public void MyArrayList_CreateObjectWithArray_ObjectIsNotNull()
        {
            //arrenge
            MyArrayList<int> array;

            //act
            array = new MyArrayList<int>(new int[3] { 2, 1, 4 });

            //assert
            Assert.NotNull(array);
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
        public void MyArrayList_CreateObjectWithMyArrayList_ObjectIsNotNull()
        {
            //arrenge
            MyArrayList<int> array = new MyArrayList<int>();

            //act
            var newArray = new MyArrayList<int>(array);

            //assert
            Assert.NotNull(array);
        }
    }
}