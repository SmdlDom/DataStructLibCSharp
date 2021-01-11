using DataStructLib.ArrayBackedStruct.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructLib.ArrayBackedStruct.MapStruct.Abstract {
    public abstract class HashMapBase : ArrayBacked {

        //TODO implement hash structure

        //Hash function variable
        private int _prime;
        private int _scale;
        private int _shift;
        private int _mask;

        //Set the field related to the hash function. O(1)
        protected void SetHashFunction(int cap, int prime) {
            Random rnd = new Random();
            _prime = prime;
            _scale = 1 + rnd.Next(prime - 1);
            _shift = rnd.Next(prime);
            _mask = cap;
        }

        protected int HashFunction(int key) {
            return ((key * _scale + _shift) % _prime) % _mask;
        }


    }
}
