Here is a JavaScript solution for finding the kth smallest element in a Binary Search Tree (BST):

```javascript
class Node {
    constructor(data) {
        this.data = data;
        this.left = null;
        this.right = null;
    }
}

class BinarySearchTree {
    constructor() {
        this.root = null;
    }

    insert(data) {
        let newNode = new Node(data);
        if (this.root === null) {
            this.root = newNode;
        } else {
            this.insertNode(this.root, newNode);
        }
    }

    insertNode(node, newNode) {
        if (newNode.data < node.data) {
            if (node.left === null) {
                node.left = newNode;
            } else {
                this.insertNode(node.left, newNode);
            }
        } else {
            if (node.right === null) {
                node.right = newNode;
            } else {
                this.insertNode(node.right, newNode);
            }
        }
    }

    kthSmallest(root, k) {
        let stack = [];
        while (true) {
            while (root != null) {
                stack.push(root);
                root = root.left;
            }
            root = stack.pop();
            if (--k == 0) return root.data;
            root = root.right;
        }
    }
}

let BST = new BinarySearchTree();
BST.insert(8);
BST.insert(3);
BST.insert(10);
BST.insert(1);
BST.insert(6);
BST.insert(14);
BST.insert(4);
BST.insert(7);
BST.insert(13);

console.log(BST.kthSmallest(BST.root, 3));
```

This solution uses a Binary Search Tree data structure. The `insert` method is used to add elements to the tree. The `kthSmallest` method is used to find the kth smallest element in the tree. It uses a stack to perform an in-order traversal of the tree (left, root, right). The kth smallest element is the kth element visited during the in-order traversal.