using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prep.codekata
{
	public class BloomFilter
	{
		IBitVector _vector = new BasicIntBitVector(0);
		List<IHasher> _hashers = new List<IHasher>();

		public BloomFilter()
		{
			_hashers.Add(new VeryBasicHasher());
		}

		public bool CheckWord(string p)
		{
			throw new NotImplementedException();
		}

		public void BuildTable(IEnumerable<string> words)
		{
			foreach (var word in words)
			{
				_vector = _vector.Or(GetHash(word));
			}
		}

		private IBitVector GetHash(string word)
		{
			IBitVector vector = new BasicIntBitVector(0);
			foreach (var hasher in _hashers)
			{
				int pos = hasher.Hash(word);
				vector = vector.Or(new BasicIntBitVector(0x1 << pos));
			}

			return vector;
		}
	}

	public interface IHasher
	{
		int Hash(string str);
	}

	public class VeryBasicHasher : IHasher
	{
		public int Hash(string str)
		{
			return str.GetHashCode() % 32;
		}
	}

	public interface IBitVector
	{
		IBitVector Or(IBitVector rightSide);
		bool ContainsValue(IBitVector rightSide);
		int SizeInBits { get; }
	}

	public class BasicIntBitVector : IBitVector
	{
		private int _bits = 0x0;

		public BasicIntBitVector(int bits)
		{
			this._bits = bits;
		}

		public IBitVector Or(IBitVector rightSide)
		{
			var bv = rightSide as BasicIntBitVector;
			return new BasicIntBitVector(bv._bits | this._bits);
		}

		public int SizeInBits
		{
			get { return 32; }
		}

		public bool ContainsValue(IBitVector rightSide)
		{
			var bv = rightSide as BasicIntBitVector;
			return ((bv._bits & this._bits) == bv._bits);
		}
	}
}
