using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;
using Xunit;

namespace TestTree
{
    public class TestNode
    {
        [Fact]
        public void Node_CreateNodeWithValue_NodeIsNotNull()
        {
            //arrenge
            Node<int> node;

            //act
            node = new Node<int>(100);

            //assert
            Assert.NotNull(node);
        }

        [Fact]
        public void Node_CreateNode_NodeIsNotNull()
        {
            //arrenge
            Node<int> node = null;

            //act
            node = new Node<int>();

            //assert
            Assert.NotNull(node);
        }
        
    }
}
