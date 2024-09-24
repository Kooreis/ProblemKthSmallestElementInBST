```cpp
#include <iostream>
#include <stack>

using namespace std;

struct Node {
    int data;
    Node* left;
    Node* right;
};

Node* createNode(int data) {
    Node* newNode = new Node();
    if (!newNode) {
        cout << "Memory error\n";
        return NULL;
    }
    newNode->data = data;
    newNode->left = newNode->right = NULL;
    return newNode;
}

Node* insertNode(Node* root, int data) {
    if (root == NULL) {
        root = createNode(data);
        return root;
    }

    if (data < root->data) {
        root->left = insertNode(root->left, data);
    }
    else {
        root->right = insertNode(root->right, data);
    }

    return root;
}

int KthSmallestElement(Node* root, int k) {
    stack<Node*> s;
    Node* curr = root;

    while (curr != NULL || s.empty() == false) {
        while (curr != NULL) {
            s.push(curr);
            curr = curr->left;
        }

        curr = s.top();
        s.pop();

        k--;

        if (k == 0)
            break;

        curr = curr->right;
    }

    return curr->data;
}

int main() {
    Node* root = NULL;
    root = insertNode(root, 15);
    insertNode(root, 10);
    insertNode(root, 20);
    insertNode(root, 8);
    insertNode(root, 12);
    insertNode(root, 17);
    insertNode(root, 25);
    int k = 3;
    cout << KthSmallestElement(root, k) << endl;

    return 0;
}
```