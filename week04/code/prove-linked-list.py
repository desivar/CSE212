

class LinkedList:
    """
     An inner class= real name is related to 
    the outer class.  To create a Node object, need to specify LinkedList.Node
    """

    class Node:
        

        def __init__(self, data):
            """ 
              in the first part of the class,
            the links are unknown so they are set to None.
            """
            self.data = data
            self.next = None
            self.prev = None

    def __init__(self):
        """
        This is an empty linked list.
        """
        self.head = None
        self.tail = None

    def insert_head(self, value):
        """
        Insert a new node
        """
        # Create the new node
        new_node = LinkedList.Node(value)  
        
        # If the list is empty
        if self.head is None:
            self.head = new_node
            self.tail = new_node
        # If the list is not empty
        else:
            new_node.next = self.head # Connect 
            self.head.prev = new_node # Connect 
            self.head = new_node      # Update 

    # Problem 1 Insert Tail
    def insert_tail(self, value):
        """
        Insert a new node at the back remember the code for insert_head.
        """
        new_node = LinkedList.Node(value)
        if self.head is None:
            self.head = new_node
            self.tail = new_node
        else:
            new_node.prev = self.tail
            self.tail.next = new_node
            self.tail = new_node

    #

    def remove_head(self):
        """ 
        Remove the first node of the linked list.
        """
    
        if self.head == self.tail:
            self.head = None
            self.tail = None
        
        elif self.head is not None:
            self.head.next.prev = None  
            self.head = self.head.next  

    
    #  Problem 2  Remove 
    def remove_tail(self):
        """
        Remove the last node  of the linked list
        """
        if self.head == self.tail:
            self.head = None
            self.tail = None
        elif self.tail is not None:
            self.tail.prev.next = None
            self.tail = self.tail.prev
    # 

    def insert_after(self, value, new_value):
        """
        Insert 'new_value' 
        """
        # Search for the matching value
        curr = self.head
        while curr is not None:
            if curr.data == value:
            
                if curr == self.tail:
                    self.insert_tail(new_value)
                
                else:
                    new_node = LinkedList.Node(new_value)
                    new_node.prev = curr       # Son conecciones
                    new_node.next = curr.next  
                    curr.next.prev = new_node  
                    curr.next = new_node       
                return # =exit
            curr = curr.next 

    
    #  Problem 3 #
    
    def remove(self, value):
        """
        Remove look and remove 
        """
        curr = self.head
        while curr is not None:
            if curr.data == value:
                if curr == self.head:
                    self.remove_head()
                elif curr == self.tail:
                    self.remove_tail()
                else:
                    curr.prev.next = curr.next
                    curr.next.prev = curr.prev
                return
            curr = curr.next

    #

    #  Problem 4 
    
    def replace(self, old_value, new_value):
        """
        Cuando busca el valor que estaba antes y lo reemplaza por el nuevo valor
        """
        curr = self.head
        while curr is not None:
            if curr.data == old_value:
                curr.data = new_value
            curr = curr.next

    #

    def __iter__(self):
        """
        empieza 
        """
        curr = self.head  
        while curr is not None:
            yield curr.data  
            curr = curr.next 

    #  Problem 5 
    def __reversed__(self):
        """
        reverted interaction
        """
        curr = self.tail
        while curr is not None:
            yield curr.data
            curr = curr.prev
    #

    def __str__(self):
        """
        Return a string representation of the linked list.
        """
        output = "linkedlist["
        first = True
        for value in self:
            if first:
                first = False
            else:
                output += ", "
            output += str(value)
        output += "]"
        return output

    
# i.e. 
print("\n=========== PROBLEM 1 TESTS ===========")
ll = LinkedList()
ll.insert_tail(1)
ll.insert_head(2)
ll.insert_head(2)
ll.insert_head(2)
ll.insert_head(3)
ll.insert_head(4)
ll.insert_head(5)
print(ll) # linkedlist[5, 4, 3, 2, 2, 2, 1]
ll.insert_tail(0)
ll.insert_tail(-1)
print(ll) # linkedlist[5, 4, 3, 2, 2, 2, 1, 0, -1]

print("\n=========== PROBLEM 2 TESTS ===========")
ll.remove_tail()
print(ll) # linkedlist[5, 4, 3, 2, 2, 2, 1, 0]
ll.remove_tail()
print(ll) # linkedlist[5, 4, 3, 2, 2, 2, 1]

print("\n=========== PROBLEM 3 TESTS ===========")
ll.insert_after(3, 3.5)
ll.insert_after(5, 6)
print(ll) # linkedlist[5, 6, 4, 3, 3.5, 2, 2, 2, 1]
ll.remove(-1)
print(ll) # linkedlist[5, 6, 4, 3, 3.5, 2, 2, 2, 1]
ll.remove(3)
print(ll) # linkedlist[5, 6, 4, 3.5, 2, 2, 2, 1]
ll.remove(6)
print(ll) # linkedlist[5, 4, 3.5, 2, 2, 2, 1]
ll.remove(1)
print(ll) # linkedlist[5, 4, 3.5, 2, 2, 2]
ll.remove(7)
print(ll) # linkedlist[5, 4, 3.5, 2, 2, 2]
ll.remove(5)
print(ll) # linkedlist[4, 3.5, 2, 2, 2]
ll.remove(2)
print(ll) # linkedlist[4, 3.5, 2, 2]

print("\n=========== PROBLEM 4 TESTS ===========")
ll.replace(2, 10)
print(ll) # linkedlist[4, 3.5, 10, 10]
ll.replace(7, 5)
print(ll) # linkedlist[4, 3.5, 10, 10]
ll.replace(4, 100)
print(ll) # linkedlist[100, 3.5, 10, 10]


print("\n=========== PROBLEM 5 TESTS ===========")
print(list(reversed(ll)))  # [10, 10, 3.5, 100]