using System;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Moq.Microsoft.Configuration.Tests.Setups.SectionSetupTests
{
	public sealed class ReturnsClassArraysShould : MockTestsBase
	{
		[Fact]
		public void SetupClassWithBoolArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new[] { true, false }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Values))
				.Get<bool[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithBoolArraysBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new[] { true, false }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = bool.Parse(
					section[$"{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithBoolArraysBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new[] { true, false }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = bool.Parse(
					fixture.Object[$"{key}:{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableBoolArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new bool?[] { true, false, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Values))
				.Get<bool?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithNullableBoolArraysBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new bool?[] { true, false, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = section[$"{nameof(value.Values)}:{i}"];

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
		public void SetupClassWithBoolNullableArraysBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new bool?[] { true, false, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{key}:{nameof(value.Values)}:{i}"];

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
			const string key = nameof(key);
			var value = new
			{
				Values = new byte[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Values))
				.Get<byte[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithByteArraysBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new byte[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = byte.Parse(
					section[$"{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithByteArraysBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new byte[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = byte.Parse(
					fixture.Object[$"{key}:{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableByteArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new byte?[] { 1, 2, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Values))
				.Get<byte?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithNullableByteArraysBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new byte?[] { 1, 2, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = section[$"{nameof(value.Values)}:{i}"];

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
		public void SetupClassWithNullableByteArraysBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new byte?[] { 1, 2, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{key}:{nameof(value.Values)}:{i}"];

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
			const string key = nameof(key);
			var value = new
			{
				Values = new sbyte[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Values))
				.Get<sbyte[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithSbyteArraysBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new sbyte[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = sbyte.Parse(
					section[$"{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithSbyteArraysBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new sbyte[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = sbyte.Parse(
					fixture.Object[$"{key}:{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableSbyteArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new sbyte?[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Values))
				.Get<sbyte?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithNullableSbyteArraysBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new sbyte?[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = section[$"{nameof(value.Values)}:{i}"];

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
		public void SetupClassWithNullableSbyteArraysBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new sbyte?[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);
			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{key}:{nameof(value.Values)}:{i}"];

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
			const string key = nameof(key);
			var value = new
			{
				Values = new[] { '日', '本' }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Values))
				.Get<char[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithCharArraysBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new[] { '日', '本' }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = char.Parse(
					section[$"{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithCharArraysBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new[] { '日', '本' }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = char.Parse(
					fixture.Object[$"{key}:{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableCharArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new char?[] { '日', '本', null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Values))
				.Get<char?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithNullableCharArraysBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new char?[] { '日', '本', null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = section[$"{nameof(value.Values)}:{i}"];

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
		public void SetupClassWithNullableCharArraysBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new char?[] { '日', '本', null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{key}:{nameof(value.Values)}:{i}"];

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
			const string key = nameof(key);
			var value = new
			{
				Values = new[] { 1.3m, 2.45m }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Values))
				.Get<decimal[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithDecimalArraysBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new[] { 1.3m, 2.45m }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = decimal.Parse(
					section[$"{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithDecimalArraysBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new[] { 1.3m, 2.45m }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = decimal.Parse(
					fixture.Object[$"{key}:{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableDecimalArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new decimal?[] { 1.3m, 2.45m, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Values))
				.Get<decimal?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithNullableDecimalArraysBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new decimal?[] { 1.3m, 2.45m, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = section[$"{nameof(value.Values)}:{i}"];

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
		public void SetupClassWithNullableDecimalArraysBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new decimal?[] { 1.3m, 2.45m, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{key}:{nameof(value.Values)}:{i}"];

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
			const string key = nameof(key);
			var value = new
			{
				Values = new[] { 1.2d, 2.33d }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Values))
				.Get<double[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithDoubleArraysBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new[] { 1.2d, 2.33d }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = double.Parse(
					section[$"{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithDoubleArraysBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new[] { 1.2d, 2.33d }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = double.Parse(
					fixture.Object[$"{key}:{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableDoubleArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new double?[] { 1.2d, 2.33d, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Values))
				.Get<double?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithNullableDoubleArraysBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new double?[] { 1.2d, 2.33d, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = section[$"{nameof(value.Values)}:{i}"];

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
		public void SetupClassWithNullableDoubleArraysBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new double?[] { 1.2d, 2.33d, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{key}:{nameof(value.Values)}:{i}"];

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
			const string key = nameof(key);
			var value = new
			{
				Values = new[] { 1.2f, 2.33f }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Values))
				.Get<float[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithFloatArraysBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new[] { 1.2f, 2.33f }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = float.Parse(
					section[$"{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithFloatArraysBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new[] { 1.2f, 2.33f }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = float.Parse(
					fixture.Object[$"{key}:{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableFloatArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new float?[] { 1.2f, 2.33f, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Values))
				.Get<float?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithNullableFloatArraysBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new float?[] { 1.2f, 2.33f, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = section[$"{nameof(value.Values)}:{i}"];

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
		public void SetupClassWithNullableFloatArraysBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new float?[] { 1.2f, 2.33f, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{key}:{nameof(value.Values)}:{i}"];

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
			const string key = nameof(key);
			var value = new
			{
				Values = new[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Values))
				.Get<int[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithIntArraysBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = int.Parse(
					section[$"{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithIntArraysBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = int.Parse(
					fixture.Object[$"{key}:{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableIntArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new int?[] { 1, 2, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Values))
				.Get<int?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithNullableIntArraysBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new int?[] { 1, 2, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = section[$"{nameof(value.Values)}:{i}"];

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
		public void SetupClassWithNullableIntArraysBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new int?[] { 1, 2, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{key}:{nameof(value.Values)}:{i}"];

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
			const string key = nameof(key);
			var value = new
			{
				Values = new[] { 1u, 2u }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Values))
				.Get<uint[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithUintArraysBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new[] { 1u, 2u }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = uint.Parse(
					section[$"{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithUintArraysBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new[] { 1u, 2u }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = uint.Parse(
					fixture.Object[$"{key}:{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableUintArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new uint?[] { 1u, 2u, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Values))
				.Get<uint?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithNullableUintArraysBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new uint?[] { 1u, 2u, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = section[$"{nameof(value.Values)}:{i}"];

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
		public void SetupClassWithNullableUintArraysBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new uint?[] { 1u, 2u, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{key}:{nameof(value.Values)}:{i}"];

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
			const string key = nameof(key);
			var value = new
			{
				Values = new[] { 1L, 2L }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Values))
				.Get<long[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithLongArraysBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new[] { 1L, 2L }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = long.Parse(
					section[$"{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithLongArraysBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new[] { 1L, 2L }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = long.Parse(
					fixture.Object[$"{key}:{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableLongArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new long?[] { 1L, 2L, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Values))
				.Get<long?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithNullableLongArraysBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new long?[] { 1L, 2L, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = section[$"{nameof(value.Values)}:{i}"];

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
		public void SetupClassWithNullableLongArraysBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new long?[] { 1L, 2L, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{key}:{nameof(value.Values)}:{i}"];

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
			const string key = nameof(key);
			var value = new
			{
				Values = new[] { 1UL, 2UL }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Values))
				.Get<ulong[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithUlongArraysBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new[] { 1UL, 2UL }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = ulong.Parse(
					section[$"{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithUlongArraysBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new[] { 1UL, 2UL }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = ulong.Parse(
					fixture.Object[$"{key}:{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableUlongArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new ulong?[] { 1UL, 2UL, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Values))
				.Get<ulong?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithNullableUlongArraysBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new ulong?[] { 1UL, 2UL, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = section[$"{nameof(value.Values)}:{i}"];

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
		public void SetupClassWithNullableUlongArraysBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new ulong?[] { 1UL, 2UL, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{key}:{nameof(value.Values)}:{i}"];

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
			const string key = nameof(key);
			var value = new
			{
				Values = new short[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Values))
				.Get<short[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithShortArraysBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new short[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = short.Parse(
					section[$"{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithShortArraysBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new short[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = short.Parse(
					fixture.Object[$"{key}:{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableShortArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new short?[] { 1, 2, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Values))
				.Get<short?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithNullableShortArraysBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new short?[] { 1, 2, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = section[$"{nameof(value.Values)}:{i}"];

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
		public void SetupClassWithNullableShortArraysBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new short?[] { 1, 2, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{key}:{nameof(value.Values)}:{i}"];

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
			const string key = nameof(key);
			var value = new
			{
				Values = new ushort[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Values))
				.Get<ushort[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithUshortArraysBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new ushort[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = ushort.Parse(
					section[$"{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithUshortArraysBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new ushort[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var result = ushort.Parse(
					fixture.Object[$"{key}:{nameof(value.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableUshortArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new ushort?[] { 1, 2, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Values))
				.Get<ushort?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Values);
		}

		[Fact]
		public void SetupClassWithNullableUshortArraysBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new ushort?[] { 1, 2, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = section[$"{nameof(value.Values)}:{i}"];

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

		[Fact]
		public void SetupClassWithNullableUshortArraysBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Values = new ushort?[] { 1, 2, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			for (var i = 0; i < value.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{key}:{nameof(value.Values)}:{i}"];

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
