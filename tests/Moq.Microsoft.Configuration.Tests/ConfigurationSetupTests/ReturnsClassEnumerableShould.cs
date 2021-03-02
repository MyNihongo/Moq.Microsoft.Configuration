using System;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq.Microsoft.Configuration.Tests.Resources;
using Xunit;

namespace Moq.Microsoft.Configuration.Tests.ConfigurationSetupTests
{
	public sealed class ReturnsClassEnumerableShould : MockTestsBase
	{
		[Fact]
		public void ExistEnumerableNode()
		{
			var value = new
			{
				Values = new[] { true, false }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Values))
				.Exists();

			result
				.Should()
				.BeTrue();
		}
		
		[Fact]
		public void ExistItemNodes()
		{
			var value = new
			{
				Values = new[] { true, false }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Values));

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = section
					.GetSection(i.ToString())
					.Exists();

				result
					.Should()
					.BeTrue();
			}
		}
		
		[Fact]
		public void SetupClassWithBoolArrays()
		{
			var value = new
			{
				Values = new[] { true, false }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Values))
				.Get<bool[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithBoolArraysBrackets()
		{
			var value = new
			{
				Values = new[] { true, false }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = bool.Parse(
					fixture.Object[$"{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithBoolArraysGetValue()
		{
			var value = new
			{
				Values = new[] { true, false }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = fixture.Object.GetValue<bool>($"{nameof(value.Values)}:{i}");

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableBoolArrays()
		{
			var value = new
			{
				Values = new bool?[] { true, false, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Values))
				.Get<bool?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithNullableBoolArraysBrackets()
		{
			var value = new
			{
				Values = new bool?[] { true, false, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{nameof(value.Values)}:{i}"];

				var result = value.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (bool?)null : throw new Exception(),
					_ => bool.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithByteArrays()
		{
			var value = new
			{
				Values = new byte[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Values))
				.Get<byte[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithByteArraysBrackets()
		{
			var value = new
			{
				Values = new byte[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = byte.Parse(
					fixture.Object[$"{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableByteArrays()
		{
			var value = new
			{
				Values = new byte?[] { 1, 2, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Values))
				.Get<byte?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithNullableByteArraysBrackets()
		{
			var value = new
			{
				Values = new byte?[] { 1, 2, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{nameof(value.Values)}:{i}"];

				var result = value.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (byte?)null : throw new Exception(),
					_ => byte.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithSbyteArrays()
		{
			var value = new
			{
				Values = new sbyte[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Values))
				.Get<sbyte[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithSbyteArraysBrackets()
		{
			var value = new
			{
				Values = new sbyte[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = sbyte.Parse(
					fixture.Object[$"{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableSbyteArrays()
		{
			var value = new
			{
				Values = new sbyte?[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Values))
				.Get<sbyte?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithNullableSbyteArraysBrackets()
		{
			var value = new
			{
				Values = new sbyte?[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{nameof(value.Values)}:{i}"];

				var result = value.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (sbyte?)null : throw new Exception(),
					_ => sbyte.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithCharArrays()
		{
			var value = new
			{
				Values = new[] { '日', '本' }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Values))
				.Get<char[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithCharArraysBrackets()
		{
			var value = new
			{
				Values = new[] { '日', '本' }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = char.Parse(
					fixture.Object[$"{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableCharArrays()
		{
			var value = new
			{
				Values = new char?[] { '日', '本', null }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Values))
				.Get<char?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithNullableCharArraysBrackets()
		{
			var value = new
			{
				Values = new char?[] { '日', '本', null }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{nameof(value.Values)}:{i}"];

				var result = value.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (char?)null : throw new Exception(),
					_ => char.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithDecimalArrays()
		{
			var value = new
			{
				Values = new[] { 1.3m, 2.45m }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Values))
				.Get<decimal[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithDecimalArraysBrackets()
		{
			var value = new
			{
				Values = new[] { 1.3m, 2.45m }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = decimal.Parse(
					fixture.Object[$"{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableDecimalArrays()
		{
			var value = new
			{
				Values = new decimal?[] { 1.3m, 2.45m, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Values))
				.Get<decimal?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithNullableDecimalArraysBrackets()
		{
			var value = new
			{
				Values = new decimal?[] { 1.3m, 2.45m, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{nameof(value.Values)}:{i}"];

				var result = value.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (decimal?)null : throw new Exception(),
					_ => decimal.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithDoubleArrays()
		{
			var value = new
			{
				Values = new[] { 1.2d, 2.33d }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Values))
				.Get<double[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithDoubleArraysBrackets()
		{
			var value = new
			{
				Values = new[] { 1.2d, 2.33d }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = double.Parse(
					fixture.Object[$"{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableDoubleArrays()
		{
			var value = new
			{
				Values = new double?[] { 1.2d, 2.33d, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Values))
				.Get<double?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithNullableDoubleArraysBrackets()
		{
			var value = new
			{
				Values = new double?[] { 1.2d, 2.33d, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{nameof(value.Values)}:{i}"];

				var result = value.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (double?)null : throw new Exception(),
					_ => double.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithFloatArrays()
		{
			var value = new
			{
				Values = new[] { 1.2f, 2.33f }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Values))
				.Get<float[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithFloatArraysBrackets()
		{
			var value = new
			{
				Values = new[] { 1.2f, 2.33f }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = float.Parse(
					fixture.Object[$"{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableFloatArrays()
		{
			var value = new
			{
				Values = new float?[] { 1.2f, 2.33f, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Values))
				.Get<float?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithNullableFloatArraysBrackets()
		{
			var value = new
			{
				Values = new float?[] { 1.2f, 2.33f, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{nameof(value.Values)}:{i}"];

				var result = value.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (float?)null : throw new Exception(),
					_ => float.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithIntArrays()
		{
			var value = new
			{
				Values = new[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Values))
				.Get<int[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithIntArraysBrackets()
		{
			var value = new
			{
				Values = new[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = int.Parse(
					fixture.Object[$"{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableIntArrays()
		{
			var value = new
			{
				Values = new int?[] { 1, 2, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Values))
				.Get<int?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithNullableIntArraysBrackets()
		{
			var value = new
			{
				Values = new int?[] { 1, 2, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{nameof(value.Values)}:{i}"];

				var result = value.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (int?)null : throw new Exception(),
					_ => int.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithUintArrays()
		{
			var value = new
			{
				Values = new[] { 1u, 2u }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Values))
				.Get<uint[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithUintArraysBrackets()
		{
			var value = new
			{
				Values = new[] { 1u, 2u }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = uint.Parse(
					fixture.Object[$"{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableUintArrays()
		{
			var value = new
			{
				Values = new uint?[] { 1u, 2u, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Values))
				.Get<uint?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithNullableUintArraysBrackets()
		{
			var value = new
			{
				Values = new uint?[] { 1u, 2u, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{nameof(value.Values)}:{i}"];

				var result = value.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (uint?)null : throw new Exception(),
					_ => uint.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithLongArrays()
		{
			var value = new
			{
				Values = new[] { 1L, 2L }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Values))
				.Get<long[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithLongArraysBrackets()
		{
			var value = new
			{
				Values = new[] { 1L, 2L }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = long.Parse(
					fixture.Object[$"{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithEnumLongArrays()
		{
			var value = new
			{
				Values = new[] { LongEnum.Val1, LongEnum.Val2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Values))
				.Get<LongEnum[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithNullableLongArrays()
		{
			var value = new
			{
				Values = new long?[] { 1L, 2L, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Values))
				.Get<long?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithNullableLongArraysBrackets()
		{
			var value = new
			{
				Values = new long?[] { 1L, 2L, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{nameof(value.Values)}:{i}"];

				var result = value.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (long?)null : throw new Exception(),
					_ => long.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithUlongArrays()
		{
			var value = new
			{
				Values = new[] { 1UL, 2UL }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Values))
				.Get<ulong[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithUlongArraysBrackets()
		{
			var value = new
			{
				Values = new[] { 1UL, 2UL }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = ulong.Parse(
					fixture.Object[$"{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableUlongArrays()
		{
			var value = new
			{
				Values = new ulong?[] { 1UL, 2UL, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Values))
				.Get<ulong?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithNullableUlongArraysBrackets()
		{
			var value = new
			{
				Values = new ulong?[] { 1UL, 2UL, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{nameof(value.Values)}:{i}"];

				var result = value.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (ulong?)null : throw new Exception(),
					_ => ulong.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithShortArrays()
		{
			var value = new
			{
				Values = new short[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Values))
				.Get<short[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithShortArraysBrackets()
		{
			var value = new
			{
				Values = new short[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = short.Parse(
					fixture.Object[$"{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableShortArrays()
		{
			var value = new
			{
				Values = new short?[] { 1, 2, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Values))
				.Get<short?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithNullableShortArraysBrackets()
		{
			var value = new
			{
				Values = new short?[] { 1, 2, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{nameof(value.Values)}:{i}"];

				var result = value.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (short?)null : throw new Exception(),
					_ => short.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithUshortArrays()
		{
			var value = new
			{
				Values = new ushort[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Values))
				.Get<ushort[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithUshortArraysBrackets()
		{
			var value = new
			{
				Values = new ushort[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = ushort.Parse(
					fixture.Object[$"{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableUshortArrays()
		{
			var value = new
			{
				Values = new ushort?[] { 1, 2, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Values))
				.Get<ushort?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithNullableUshortArraysBrackets()
		{
			var value = new
			{
				Values = new ushort?[] { 1, 2, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{nameof(value.Values)}:{i}"];

				var result = value.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (ushort?)null : throw new Exception(),
					_ => ushort.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Values[i]);
			}
		}
	}
}
