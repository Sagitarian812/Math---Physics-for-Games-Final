using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ListUtility
{
	public static class ListUtil
	{
		public static void Add<T>(this List<T> list, params T[] entries)
		{
			foreach (T entry in entries)
			{
				list.Add(entry);
			}
		}
	}
}