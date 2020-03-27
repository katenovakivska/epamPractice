using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Tree;

namespace TestCollections
{
    public class TestTree
    {
        [Fact]
        public void GetEnumerator_GetEnumeratorForeach_NotCheckElementsInEmptyTree()
        {
            //arrenge
            var tree = new MyTree<int>();
            bool check = true;

            //act
            foreach (var el in tree)
            {
                check = false;
            }

            //assert
            Assert.True(check);
        }
        /// <summary>
        /// ------
        /// </summary>
        [Fact]
        public void GetEnumerator_GetEnumeratorForLevelTraverse_TraverseElementsInLevelOrder()
        {
            //arrenge
            var tree = new MyTree<int>();
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(6);
            tree.Insert(1);
            tree.Insert(8);
            string elements = "";

            //act
            foreach (var el in tree)
            {
                elements += ($"{el}");
            }

            //assert
            Assert.Equal(5, elements.Length);
        }


        [Fact]
        public void Insert_InsertFirstElement_TreeContainsValue()
        {
            //arrenge
            var tree = new MyTree<int>();

            //act
            tree.Insert(5);
            var result = tree.Find(5);

            //assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Insert_InsertNullNode_ArgumentNullException()
        {
            //arrenge
            var tree = new MyTree<string>();

            //act
            Action action = () => tree.Insert(null);

            //assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void Insert_InsertedObjectCallEvent_ReturnValueOfObjectThatCallEvent()
        {
            //arrenge
            var tree = new MyTree<string>();
            var actual = new MyTreeEventArgs<string>("");

            //act
            tree.OnInsert += (o, s) => { actual = s; };
            tree.Insert("");

            //assert
            Assert.Equal("", actual.Element.ToString());
        }

        [Fact]
        public void Remove_RemoveRootValue_SetNewRootValue()
        {
            //arrenge
            var tree = new MyTree<int>();
            var remove = 5;
            tree.Insert(5);
            tree.Insert(2);
            tree.Insert(6);

            //act
            tree.Remove(remove);
            var result = tree.Find(remove);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void Remove_RemoveRootValue_IfOneChildIsNullChooseAnother()
        {
            //arrenge
            var tree = new MyTree<int>();
            tree.Insert(5);
            tree.Insert(2);
            var remove = 5;

            //act
            tree.Remove(remove);

            //assert
            Assert.Equal(remove.ToString(), tree.Root.Data.ToString());
        }

        [Fact]
        public void Remove_RemoveNode_RemovedNodeNotFindAndAnotherTakeItsPlace()
        {
            //arrenge
            var tree = new MyTree<int>();
            tree.Insert(3);
            tree.Insert(6);
            tree.Insert(5);
            tree.Insert(4);
            var remove = 5;

            //act
            tree.Remove(remove);
            var result = tree.Find(5);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void RemoveVoid_RemoveNullNode_ArgumentNullException()
        {
            //arrenge
            var tree = new MyTree<string>();
            tree.Insert("one");
            tree.Insert("two");
            tree.Insert("three");

            //act
            Action action = () => tree.Remove(null);

            //assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void Remove_RemoveObjectCallEvent_ReturnValueOfObjectThatCallEvent()
        {
            //arrenge
            var tree = new MyTree<string>();
            tree.Insert("");
            var actual = new MyTreeEventArgs<string>("");

            //act
            tree.OnRemove += (o, s) => { actual = s; };
            tree.Remove("");

            //assert
            Assert.Equal("", actual.Element.ToString());
        }

        [Fact]
        public void MinValue_MinValueForElementSubtree_MinValueInLeftSubtreeFounded()
        {
            //arrenge
            var tree = new MyTree<int>();
            tree.Insert(5);
            tree.Insert(2);
            tree.Insert(6);
            tree.Insert(1);
            tree.Insert(8);
            var node = tree.Root;

            //act
            var min = tree.MinValue(node);

            //assert
            Assert.Equal("1", min.ToString());
        }

        [Fact]
        public void Find_SearchNodeByValue_ReturnTrueIfNodeIsInTree()
        {
            //arrenge
            var tree = new MyTree<int>();
            tree.Insert(3);
            tree.Insert(2);
            tree.Insert(6);
            tree.Insert(5);
            tree.Insert(8);

            //act
            var isValue = tree.Find(5);

            //assert
            Assert.True(isValue);
        }

        [Fact]
        public void Find_SearchNullValue_ArgumentNullException()
        {
            //arrenge
            var tree = new MyTree<string>();
            tree.Insert("one");
            tree.Insert("two");
            tree.Insert("three");

            //act
            Action action = () => tree.Find(null);

            //assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void GetEnumerator_GetEnumeratorForTree_EnumeratorIsNotNull()
        {
            //arrange
            MyTree<int> tree = new MyTree<int>();
            tree.Insert(10);
            tree.Insert(15);
            tree.Insert(1);

            //act
            IEnumerator result = ((IEnumerable)tree).GetEnumerator();

            //assert
            Assert.NotNull(result);
        }
    }
}
