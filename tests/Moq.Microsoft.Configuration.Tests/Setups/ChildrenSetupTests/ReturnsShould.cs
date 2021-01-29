using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Moq.Microsoft.Configuration.Tests.Setups.ChildrenSetupTests
{
	public sealed class ReturnsShould : MockTestsBase
	{
		[Fact]
		public void ReturnStringEnumerable()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(x => $"string {x}")
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<string>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<IEnumerable<string>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnStringArray()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(x => $"string {x}")
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<string>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<string[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnStringList()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(x => $"string {x}")
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<string>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<List<string>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnBoolEnumerable()
		{
			const string key = nameof(key);
			var input = new[] { true, false, true };

			var fixture = CreateClass();

			fixture
				.SetupChildren<bool>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<IEnumerable<bool>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnBoolArray()
		{
			const string key = nameof(key);
			var input = new[] { true, false, true };

			var fixture = CreateClass();

			fixture
				.SetupChildren<bool>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<bool[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnBoolList()
		{
			const string key = nameof(key);
			var input = new[] { true, false, true };

			var fixture = CreateClass();

			fixture
				.SetupChildren<bool>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<List<bool>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnCharEnumerable()
		{
			const string key = nameof(key);
			var input = new[] { 'A', 'b', '3' };

			var fixture = CreateClass();

			fixture
				.SetupChildren<char>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<IEnumerable<char>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnCharArray()
		{
			const string key = nameof(key);
			var input = new[] { 'A', 'b', '3' };

			var fixture = CreateClass();

			fixture
				.SetupChildren<char>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<char[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnCharList()
		{
			const string key = nameof(key);
			var input = new[] { 'A', 'b', '3' };

			var fixture = CreateClass();

			fixture
				.SetupChildren<char>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<List<char>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnByteEnumerable()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToByte)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<byte>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<IEnumerable<byte>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnByteArray()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToByte)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<byte>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<byte[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnByteList()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToByte)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<byte>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<List<byte>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnSbyteEnumerable()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToSByte)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<sbyte>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<IEnumerable<sbyte>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnSbyteArray()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToSByte)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<sbyte>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<sbyte[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnSbyteList()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToSByte)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<sbyte>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<List<sbyte>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnIntEnumerable()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<int>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<IEnumerable<int>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnIntArray()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<int>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<int[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnIntList()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<int>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<List<int>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnUintEnumerable()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToUInt32)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<uint>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<IEnumerable<uint>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnUintArray()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToUInt32)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<uint>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<uint[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnUintList()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToUInt32)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<uint>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<List<uint>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnLongEnumerable()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToInt64)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<long>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<IEnumerable<long>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnLongArray()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToInt64)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<long>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<long[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnLongList()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToInt64)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<long>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<List<long>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnUlongEnumerable()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToUInt64)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<ulong>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<IEnumerable<ulong>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnUlongArray()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToUInt64)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<ulong>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<ulong[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnUlongList()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToUInt64)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<ulong>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<List<ulong>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnShortEnumerable()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToInt16)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<short>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<IEnumerable<short>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnShortArray()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToInt16)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<short>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<short[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnShortList()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToInt16)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<short>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<List<short>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnUshortEnumerable()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToUInt16)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<ushort>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<IEnumerable<ushort>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnUshortArray()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToUInt16)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<ushort>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<ushort[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnUshortList()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToUInt16)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<ushort>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<List<ushort>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnDecimalEnumerable()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToDecimal)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<decimal>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<IEnumerable<decimal>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnDecimalArray()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToDecimal)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<decimal>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<decimal[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnDecimalList()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToDecimal)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<decimal>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<List<decimal>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnDoubleEnumerable()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToDouble)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<double>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<IEnumerable<double>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnDoubleArray()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToDouble)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<double>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<double[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnDoubleList()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToDouble)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<double>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<List<double>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnFloatEnumerable()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToSingle)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<float>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<IEnumerable<float>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnFloatArray()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToSingle)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<float>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<float[]>();

			result
				.Should()
				.BeEquivalentTo(input);
		}

		[Fact]
		public void ReturnFloatList()
		{
			const string key = nameof(key);

			var input = Enumerable.Range(1, 5)
				.Select(Convert.ToSingle)
				.ToArray();

			var fixture = CreateClass();

			fixture
				.SetupChildren<float>(key)
				.Returns(input);

			var result = fixture.Object
				.GetSection(key)
				.Get<List<float>>();

			result
				.Should()
				.BeEquivalentTo(input);
		}
	}
}
