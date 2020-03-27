using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;
using Xunit;

namespace TestTree
{
    public class TestMyTreeEventArgs
    {
        [Fact]
        public void MyTreeEventArgs_CreateObject_ObjectIsNotNull()
        {
            //arrenge
            MyTreeEventArgs<int> args;

            //act
            args = new MyTreeEventArgs<int>();

            //assert
            Assert.NotNull(args);
        }

        [Fact]
        public void MyTreeEventArgs_CreateObjectWithValue_ObjectIsNotNull()
        {
            //arrenge
            MyTreeEventArgs<int> args;

            //act
            args = new MyTreeEventArgs<int>(5);

            //assert
            Assert.NotNull(args);
        }



    }
}
