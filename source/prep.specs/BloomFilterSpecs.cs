using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using prep.specs.utility;
using prep.codekata;

namespace prep.specs
{
	[Subject(typeof(BloomFilter))]
	public class BloomFilterSpecs
	{
		public abstract class bloom_filter_concern : Observes<BloomFilter>
		{
			protected static IList<string> words_collection;

			protected static void LoadWords()
			{
				string fileName = @"C:\WORDLIST.TXT";
				using (var sr = new StreamReader(fileName))
				{
					words_collection.Add(sr.ReadLine());
				}
			}

			Establish c = () =>
			{
				words_collection = new List<string>();
				LoadWords();
			};
		};

		public class when_building_list_of_dictionary_words : bloom_filter_concern
		{
			Because b = () =>
							{
								sut.BuildTable(words_collection);
								result = sut.CheckWord("fkdk");
							};

			It should_iterate = () =>
			{
			};

			static bool result;
		}
	}
}
