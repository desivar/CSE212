class LinkedList:
    """
    Implement the LinkedList data structure. The Node class below is an 
    inner class. An inner class means that its real name is related to 
    the outer class. To create a Node object, we will need to 
    specify LinkedList.Node.
    """

    class Node:
        """
        Each node connects to the next and previous nodes.
        """

        def __init__(self, data):
            """ 
            Initialize the node to the data provided. Initially
            the links are unknown so they are set to None.
            """
            self.data = data
            self.next = None
            self.prev = None

    def __init__(self):
        """
        Initialize an empty linked list.
        """
        self.head = None
        self.tail = None

    def insert_head(self, value):
        """
        Insert a new node at the front (i.e. the head) of the
        linked list.
        """
        # Create the new node
        new_node = LinkedList.Node(value)  
        
        # If the list is empty, then point both head and tail
        # to the new node.
        if self.head is None:
            self.head = new_node
            self.tail = new_node
        else:
            new_node.next = self.head  # Connect new node to the previous head
            self.head.prev = new_node  # Connect the previous head to the new node
            self.head = new_node       # Update the head to point to the new node

    def insert_tail(self, value):
        """
        Insert a new node at the back (i.e. the tail) of the 
        linked list.
        """
        # Create the new node
        new_node = LinkedList.Node(value) 

        # If the list is empty, then point both tail and head
        # to the new node.
        if self.head is None:
            self.head = new_node
            self.tail = new_node
        else:
            new_node.prev = self.tail  # Connect new node to the previous tail
            self.tail.next = new_node  # Connect the previous tail to the new node
            self.tail = new_node       # Update the tail to point to the new node

    def remove_head(self):
        """ 
        Remove the first node (i.e. the head) of the linked list.
        """
        # If the list has only one item in it, then set head and tail 
        # to None resulting in an empty list. This condition will also
        # cover an empty list. It's okay to set to None again.
        if self.head == self.tail:
            self.head = None
            self.tail = None
        elif self.head is not None:
            self.head = self.head.next  # Update the head to point to the second node
            if self.head:
                self.head.prev = None  # Disconnect the second node from the first node

    def remove_tail(self):
        """
        Remove the last node (i.e. the tail) of the linked list.
        """
        # If the list has only one item in it, then set tail and head
        # to None resulting in an empty list. This condition will also
        # cover an empty list.
        if self.tail == self.head:
            self.head = None
            self.tail = None
        elif self.tail is not None:
            self.tail = self.tail.prev  # Update the tail to point to the previous node
            if self.tail:
                self.tail.next = None  # Disconnect the previous node from the current node

    def insert_after(self, value, new_value):
        """
        Insert 'new_value' after the first occurrence of 'value' in
        the linked list.
        """
        # Search for the node that

  
      
          

   

       
              

       

   
     
            
  
