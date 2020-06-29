﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Kogane
{
	/// <summary>
	/// IEnumerable 型の拡張メソッドを管理するクラス
	/// </summary>
	public static partial class LINQExtensionMethods
	{
		//================================================================================
		// Nearest
		//================================================================================
		/// <summary>
		/// 目的の値に最も近い値を返します。見つからなかった場合は例外を投げます。
		/// </summary>
		/// <param name="target">目的の値</param>
		/// <returns>目的の値に最も近い値</returns>
		public static int Nearest
		(
			this IEnumerable<int> self,
			int                   target
		)
		{
			var list = self.ToArray();
			var min  = list.Min( c => Math.Abs( c - target ) );
			return list.First( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近い値を返します。見つからなかった場合は例外を投げます。
		/// </summary>
		/// <typeparam name="TSource">要素の型</typeparam>
		/// <param name="target">目的の値</param>
		/// <param name="selector">選択関数</param>
		/// <returns>目的の値に最も近い値</returns>
		public static int Nearest<TSource>
		(
			this IEnumerable<TSource> self,
			int                       target,
			Func<TSource, int>        selector
		)
		{
			var list = self.ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.First( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		//================================================================================
		// FindNearest
		//================================================================================
		/// <summary>
		/// 目的の値に最も近い値を持つ要素を返します。見つからなかった場合は例外を投げます。
		/// </summary>
		/// <typeparam name="TSource">要素の型</typeparam>
		/// <param name="target">目的の値</param>
		/// <param name="selector">選択関数</param>
		/// <returns>目的の値に最も近い要素</returns>
		public static TSource FindNearest<TSource>
		(
			this IEnumerable<TSource> self,
			int                       target,
			Func<TSource, int>        selector
		)
		{
			var list = self.ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.First( c => Math.Abs( selector( c ) - target ) == min );
		}

		//================================================================================
		// NearestOrDefault
		//================================================================================
		/// <summary>
		/// 目的の値に最も近い値を返します。見つからなかった場合は null を返します。
		/// </summary>
		/// <param name="target">目的の値</param>
		/// <returns>目的の値に最も近い値</returns>
		public static int NearestOrDefault
		(
			this IEnumerable<int> self,
			int                   target
		)
		{
			var list = self.ToArray();
			var min  = list.Min( c => Math.Abs( c - target ) );
			return list.FirstOrDefault( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近い値を返します。見つからなかった場合は null を返します。
		/// </summary>
		/// <typeparam name="TSource">要素の型</typeparam>
		/// <param name="target">目的の値</param>
		/// <param name="selector">選択関数</param>
		/// <returns>目的の値に最も近い値</returns>
		public static int NearestOrDefault<TSource>
		(
			this IEnumerable<TSource> self,
			int                       target,
			Func<TSource, int>        selector
		)
		{
			var list = self.ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.FirstOrDefault( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		//================================================================================
		// FindNearestOrDefault
		//================================================================================
		/// <summary>
		/// 目的の値に最も近い値を持つ要素を返します。見つからなかった場合は null を返します。
		/// </summary>
		/// <typeparam name="TSource">要素の型</typeparam>
		/// <param name="target">目的の値</param>
		/// <param name="selector">選択関数</param>
		/// <returns>目的の値に最も近い値を持つ要素</returns>
		public static TSource FindNearestOrDefault<TSource>
		(
			this IEnumerable<TSource> self,
			int                       target,
			Func<TSource, int>        selector
		)
		{
			var list = self.ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.FirstOrDefault( c => Math.Abs( selector( c ) - target ) == min );
		}

		//================================================================================
		// NearestMoreThan
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値より大きい値を返します。見つからなかった場合は例外を投げます。
		/// </summary>
		/// <param name="target">目的の値</param>
		/// <returns>目的の値に最も近く、目的の値より大きい値</returns>
		public static int NearestMoreThan
		(
			this IEnumerable<int> self,
			int                   target
		)
		{
			var list = self.Where( c => target < c ).ToArray();
			var min  = list.Min( c => Math.Abs( c - target ) );
			return list.First( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値より大きい値を返します。見つからなかった場合は例外を投げます。
		/// </summary>
		/// <typeparam name="TSource">要素の型</typeparam>
		/// <param name="target">目的の値</param>
		/// <param name="selector">選択関数</param>
		/// <returns>目的の値に最も近く、目的の値より大きい値</returns>
		public static int NearestMoreThan<TSource>
		(
			this IEnumerable<TSource> self,
			int                       target,
			Func<TSource, int>        selector
		)
		{
			var list = self.Where( c => target < selector( c ) ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.First( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		//================================================================================
		// FindNearestMoreThan
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値より大きい値を持つ要素を返します。見つからなかった場合は例外を投げます。
		/// </summary>
		/// <typeparam name="TSource">要素の型</typeparam>
		/// <param name="target">目的の値</param>
		/// <param name="selector">選択関数</param>
		/// <returns>目的の値に最も近く、目的の値より大きい値を持つ要素</returns>
		public static TSource FindNearestMoreThan<TSource>
		(
			this IEnumerable<TSource> self,
			int                       target,
			Func<TSource, int>        selector
		)
		{
			var list = self.Where( c => target < selector( c ) ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.First( c => Math.Abs( selector( c ) - target ) == min );
		}

		//================================================================================
		// NearestMoreThanOrDefault
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値より大きい値を返します。見つからなかった場合は null を返します。
		/// </summary>
		/// <param name="target">目的の値</param>
		/// <returns>目的の値に最も近く、目的の値より大きい値</returns>
		public static int NearestMoreThanOrDefault
		(
			this IEnumerable<int> self,
			int                   target
		)
		{
			var list = self.Where( c => target < c ).ToArray();
			var min  = list.Min( c => Math.Abs( c - target ) );
			return list.FirstOrDefault( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値より大きい値を返します。見つからなかった場合は null を返します。
		/// </summary>
		/// <typeparam name="TSource">要素の型</typeparam>
		/// <param name="target">目的の値</param>
		/// <param name="selector">選択関数</param>
		/// <returns>目的の値に最も近く、目的の値より大きい値</returns>
		public static int NearestMoreThanOrDefault<TSource>
		(
			this IEnumerable<TSource> self,
			int                       target,
			Func<TSource, int>        selector
		)
		{
			var list = self.Where( c => target < selector( c ) ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.FirstOrDefault( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		//================================================================================
		// FindNearestMoreThanOrDefault
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値より大きい値を持つ要素を返します。見つからなかった場合は null を返します。
		/// </summary>
		/// <typeparam name="TSource">要素の型</typeparam>
		/// <param name="target">目的の値</param>
		/// <param name="selector">選択関数</param>
		/// <returns>目的の値に最も近く、目的の値より大きい値</returns>
		public static TSource FindNearestMoreThanOrDefault<TSource>
		(
			this IEnumerable<TSource> self,
			int                       target,
			Func<TSource, int>        selector
		)
		{
			var list = self.Where( c => target < selector( c ) ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.FirstOrDefault( c => Math.Abs( selector( c ) - target ) == min );
		}

		//================================================================================
		// NearestOrLess
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値以下の値を返します。見つからなかった場合は例外を投げます。
		/// </summary>
		/// <param name="target">目的の値</param>
		/// <returns>目的の値に最も近く、目的の値以下の値</returns>
		public static int NearestOrLess
		(
			this IEnumerable<int> self,
			int                   target
		)
		{
			var list = self.Where( c => c <= target ).ToArray();
			var min  = list.Min( c => Math.Abs( c - target ) );
			return list.First( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値以下の値を返します。見つからなかった場合は例外を投げます。
		/// </summary>
		/// <typeparam name="TSource">要素の型</typeparam>
		/// <param name="target">目的の値</param>
		/// <param name="selector">選択関数</param>
		/// <returns>目的の値に最も近く、目的の値以下の値</returns>
		public static int NearestOrLess<TSource>
		(
			this IEnumerable<TSource> self,
			int                       target,
			Func<TSource, int>        selector
		)
		{
			var list = self.Where( c => selector( c ) <= target ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.First( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		//================================================================================
		// FindNearestOrLess
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値以下の値を返します。見つからなかった場合は例外を投げます。
		/// </summary>
		/// <typeparam name="TSource">要素の型</typeparam>
		/// <param name="target">目的の値</param>
		/// <param name="selector">選択関数</param>
		/// <returns>目的の値に最も近く、目的の値以下の値</returns>
		public static TSource FindNearestOrLess<TSource>
		(
			this IEnumerable<TSource> self,
			int                       target,
			Func<TSource, int>        selector
		)
		{
			var list = self.Where( c => selector( c ) <= target ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.First( c => Math.Abs( selector( c ) - target ) == min );
		}

		//================================================================================
		// NearestOrLessOrDefault
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値以下の値を返します。見つからなかった場合は null を返します。
		/// </summary>
		/// <param name="target">目的の値</param>
		/// <returns>目的の値に最も近く、目的の値以下の値</returns>
		public static int NearestOrLessOrDefault
		(
			this IEnumerable<int> self,
			int                   target
		)
		{
			var list = self.Where( c => c <= target ).ToArray();
			var min  = list.Min( c => Math.Abs( c - target ) );
			return list.FirstOrDefault( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値以下の値を返します。見つからなかった場合は null を返します。
		/// </summary>
		/// <typeparam name="TSource">要素の型</typeparam>
		/// <param name="target">目的の値</param>
		/// <param name="selector">選択関数</param>
		/// <returns>目的の値に最も近く、目的の値以下の値</returns>
		public static int NearestOrLessOrDefault<TSource>
		(
			this IEnumerable<TSource> self,
			int                       target,
			Func<TSource, int>        selector
		)
		{
			var list = self.Where( c => selector( c ) <= target ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.FirstOrDefault( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		//================================================================================
		// FindNearestOrLessOrDefault
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値以下の値を返します。見つからなかった場合は null を返します。
		/// </summary>
		/// <typeparam name="TSource">要素の型</typeparam>
		/// <param name="target">目的の値</param>
		/// <param name="selector">選択関数</param>
		/// <returns>目的の値に最も近く、目的の値以下の値</returns>
		public static TSource FindNearestOrLessOrDefault<TSource>
		(
			this IEnumerable<TSource> self,
			int                       target,
			Func<TSource, int>        selector
		)
		{
			var list = self.Where( c => selector( c ) <= target ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.FirstOrDefault( c => Math.Abs( selector( c ) - target ) == min );
		}

		//================================================================================
		// NearestOrMore
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値以上の値を返します。見つからなかった場合は例外を投げます。
		/// </summary>
		/// <param name="target">目的の値</param>
		/// <returns>目的の値に最も近く、目的の値以上の値</returns>
		public static int NearestOrMore
		(
			this IEnumerable<int> self,
			int                   target
		)
		{
			var list = self.Where( c => target <= c ).ToArray();
			var min  = list.Min( c => Math.Abs( c - target ) );
			return list.First( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値以上の値を返します。見つからなかった場合は例外を投げます。
		/// </summary>
		/// <typeparam name="TSource">要素の型</typeparam>
		/// <param name="target">目的の値</param>
		/// <param name="selector">選択関数</param>
		/// <returns>目的の値に最も近く、目的の値以上の値</returns>
		public static int NearestOrMore<TSource>
		(
			this IEnumerable<TSource> self,
			int                       target,
			Func<TSource, int>        selector
		)
		{
			var list = self.Where( c => target <= selector( c ) ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.First( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		//================================================================================
		// FindNearestOrMore
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値以上の値を返します。見つからなかった場合は例外を投げます。
		/// </summary>
		/// <typeparam name="TSource">要素の型</typeparam>
		/// <param name="target">目的の値</param>
		/// <param name="selector">選択関数</param>
		/// <returns>目的の値に最も近く、目的の値以上の値</returns>
		public static TSource FindNearestOrMore<TSource>
		(
			this IEnumerable<TSource> self,
			int                       target,
			Func<TSource, int>        selector
		)
		{
			var list = self.Where( c => target <= selector( c ) ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.First( c => Math.Abs( selector( c ) - target ) == min );
		}

		//================================================================================
		// NearestOrMoreOrDefault
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値以上の値を返します。見つからなかった場合は null を返します。
		/// </summary>
		/// <param name="target">目的の値</param>
		/// <returns>目的の値に最も近く、目的の値以上の値</returns>
		public static int NearestOrMoreOrDefault
		(
			this IEnumerable<int> self,
			int                   target
		)
		{
			var list = self.Where( c => target <= c ).ToArray();
			var min  = list.Min( c => Math.Abs( c - target ) );
			return list.FirstOrDefault( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値以上の値を返します。見つからなかった場合は null を返します。
		/// </summary>
		/// <typeparam name="TSource">要素の型</typeparam>
		/// <param name="target">目的の値</param>
		/// <param name="selector">選択関数</param>
		/// <returns>目的の値に最も近く、目的の値以上の値</returns>
		public static int NearestOrMoreOrDefault<TSource>
		(
			this IEnumerable<TSource> self,
			int                       target,
			Func<TSource, int>        selector
		)
		{
			var list = self.Where( c => target <= selector( c ) ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.FirstOrDefault( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		//================================================================================
		// FindNearestOrMoreOrDefault
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値以上の値を返します。見つからなかった場合は null を返します。
		/// </summary>
		/// <typeparam name="TSource">要素の型</typeparam>
		/// <param name="target">目的の値</param>
		/// <param name="selector">選択関数</param>
		/// <returns>目的の値に最も近く、目的の値以上の値</returns>
		public static TSource FindNearestOrMoreOrDefault<TSource>
		(
			this IEnumerable<TSource> self,
			int                       target,
			Func<TSource, int>        selector
		)
		{
			var list = self.Where( c => target <= selector( c ) ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.FirstOrDefault( c => Math.Abs( selector( c ) - target ) == min );
		}

		//================================================================================
		// NearestMoreLess
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値より小さい値を返します。見つからなかった場合は例外を投げます。
		/// </summary>
		/// <param name="target">目的の値</param>
		/// <returns>目的の値に最も近く、目的の値より小さい値</returns>
		public static int NearestMoreLess
		(
			this IEnumerable<int> self,
			int                   target
		)
		{
			var list = self.Where( c => c < target ).ToArray();
			var min  = list.Min( c => Math.Abs( c - target ) );
			return list.First( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値より小さい値を返します。見つからなかった場合は例外を投げます。
		/// </summary>
		/// <typeparam name="TSource">要素の型</typeparam>
		/// <param name="target">目的の値</param>
		/// <param name="selector">選択関数</param>
		/// <returns>目的の値に最も近く、目的の値より小さい値</returns>
		public static int NearestMoreLess<TSource>
		(
			this IEnumerable<TSource> self,
			int                       target,
			Func<TSource, int>        selector
		)
		{
			var list = self.Where( c => selector( c ) < target ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.First( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		//================================================================================
		// FindNearestMoreLess
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値より小さい値を持つ要素を返します。見つからなかった場合は例外を投げます。
		/// </summary>
		/// <typeparam name="TSource">要素の型</typeparam>
		/// <param name="target">目的の値</param>
		/// <param name="selector">選択関数</param>
		/// <returns>目的の値に最も近く、目的の値より小さい値を持つ要素</returns>
		public static TSource FindNearestMoreLess<TSource>
		(
			this IEnumerable<TSource> self,
			int                       target,
			Func<TSource, int>        selector
		)
		{
			var list = self.Where( c => selector( c ) < target ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.First( c => Math.Abs( selector( c ) - target ) == min );
		}

		//================================================================================
		// NearestMoreLessOrDefault
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値より小さい値を返します。見つからなかった場合は null を返します。
		/// </summary>
		/// <param name="target">目的の値</param>
		/// <returns>目的の値に最も近く、目的の値より小さい値</returns>
		public static int NearestMoreLessOrDefault
		(
			this IEnumerable<int> self,
			int                   target
		)
		{
			var list = self.Where( c => c < target ).ToArray();
			var min  = list.Min( c => Math.Abs( c - target ) );
			return list.FirstOrDefault( c => Math.Abs( c - target ) == min );
		}

		/// <summary>
		/// 目的の値に最も近く、目的の値より小さい値を返します。見つからなかった場合は null を返します。
		/// </summary>
		/// <typeparam name="TSource">要素の型</typeparam>
		/// <param name="target">目的の値</param>
		/// <param name="selector">選択関数</param>
		/// <returns>目的の値に最も近く、目的の値より小さい値</returns>
		public static int NearestMoreLessOrDefault<TSource>
		(
			this IEnumerable<TSource> self,
			int                       target,
			Func<TSource, int>        selector
		)
		{
			var list = self.Where( c => selector( c ) < target ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return selector( list.FirstOrDefault( c => Math.Abs( selector( c ) - target ) == min ) );
		}

		//================================================================================
		// FindNearestMoreLessOrDefault
		//================================================================================
		/// <summary>
		/// 目的の値に最も近く、目的の値より小さい値を持つ要素を返します。見つからなかった場合は null を返します。
		/// </summary>
		/// <typeparam name="TSource">要素の型</typeparam>
		/// <param name="target">目的の値</param>
		/// <param name="selector">選択関数</param>
		/// <returns>目的の値に最も近く、目的の値より小さい値を持つ要素</returns>
		public static TSource FindNearestMoreLessOrDefault<TSource>
		(
			this IEnumerable<TSource> self,
			int                       target,
			Func<TSource, int>        selector
		)
		{
			var list = self.Where( c => selector( c ) < target ).ToArray();
			var min  = list.Min( c => Math.Abs( selector( c ) - target ) );
			return list.FirstOrDefault( c => Math.Abs( selector( c ) - target ) == min );
		}
	}
}