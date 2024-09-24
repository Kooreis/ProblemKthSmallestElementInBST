Here is a TypeScript solution for finding the kth smallest element in a Binary Search Tree (BST):

```typescript
class Node {
    left: Node | null = null;
    right: Node | null = null;
    constructor(public value: number) {}
}

class BinarySearchTree {
    root: Node | null = null;

    insert(value: number) {
        let newNode = new Node(value);
        if (!this.root) {
            this.root = newNode;
            return this;
        } else {
            let current = this.root;
            while (true) {
                if (value < current.value) {
                    if (!current.left) {
                        current.left = newNode;
                        return this;
                    }
                    current = current.left;
                } else {
                    if (!current.right) {
                        current.right = newNode;
                        return this;
                    }
                    current = current.right;
                }
            }
        }
    }

    kthSmallest(k: number) {
        let stack: Node[] = [];
        let node = this.root;

        while (node) {
            stack.push(node);
            node = node.left;
        }

        while (k > 0) {
            node = stack.pop()!;
            k--;
            let right = node.right;
            while (right) {
                stack.push(right);
                right = right.left;
            }
        }

        return node!.value;
    }
}

let bst = new BinarySearchTree();
bst.insert(5);
bst.insert(3);
bst.insert(2);
bst.insert(4);
bst.insert(7);
bst.insert(6);
bst.insert(8);

console.log(bst.kthSmallest(3)); // Output: 4
```

This solution uses an in-order traversal to find the kth smallest element. The in-order traversal of a BST gives a sorted list of the elements in the tree. The kth smallest element is the kth element in this sorted list.