#include <cstdio>
#include "dynamic-array.hpp"

int main()
{
  // Create a dynamic array of int
  // and initialise it to a new dynamic array of 10 elements
  dynamic_array<int> *array = new dynamic_array<int>(10, 0);

  // Print the size and capacity of the array
  printf("size: %d, capacity: %d\n", array->size, array->capacity);

  // Add 15 values to the array
  for(int i = 0; i < 15; i++)
  {
    array->add(i);
  }

  // Reprint the size and capacity of the array after adding
  printf("size: %d, capacity: %d\n", array->size, array->capacity);

  // Print and update the values in the array, using the get and set functions
  for(int i = 0; i < array->size; i++)
  {
    printf("array[%d] =  %d\n", i, (*array)[i]);
    array->set(i, i * 2);
  }

  // Attempt to access an element out of bounds using get
  printf("array[99] = %d\n", array->get(99));

  // Attempt to access an element out of bounds using set
  if (array->set(99, 99))
  {
    printf("array[99] = %d\n", array->get(99));
  }
  else
  {
    printf("Failed to set array[99]\n");
  }

  printf("Before resize - size: %d, capacity: %d\n", array->size, array->capacity);
  // Change the size of the array
  array->resize(5);

  printf("After resize - size: %d, capacity: %d\n", array->size, array->capacity);

  for(int i = 0; i < 20; i++)
  {
    printf("array[%d] =  %d\n", i, array->get(i));
  }

  // Free the array and ensure we do not have a dangling pointer
  delete array;
  array = nullptr;

  return 0;
}
