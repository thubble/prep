using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prep.codekata
{
	public class BloomFilter
	{
		private const int VECTOR_SIZE = 1; // size in sizeof(int) = *32



		public BloomFilter(IEnumerable<string> words)
		{

		}

		public bool CheckWord(string p)
		{
			throw new NotImplementedException();
		}
	}

	public interface IHasher
	{
		IBitVector Hash(string str);
	}

	public interface IBitVector
	{
		IBitVector Or(IBitVector rightSide);
	}
}
