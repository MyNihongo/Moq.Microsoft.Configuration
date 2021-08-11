using System;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq.Microsoft.Configuration.Tests.Resources;
using Xunit;

namespace Moq.Microsoft.Configuration.Tests.ConfigurationSetupTests
{
	public sealed class ReturnsClassClassEnumerableShould : ConfigurationTestsBase
	{
		[Fact]
		public void ExistClassNode()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { true, false }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.Exists();

			result
				.Should()
				.BeTrue();
		}

		[Fact]
		public void ExistEnumerableNode()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { true, false }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetSection(nameof(value.Key.Values))
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
				Key = new
				{
					Values = new[] { true, false }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key))
				.GetSection(nameof(value.Key.Values));

			for (var i = 0; i < value.Key.Values.Length; i++)
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
				Key = new
				{
					Values = new[] { true, false }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			var result = section
				.GetSection(nameof(value.Key.Values))
				.Get<bool[]>();

			result
				.Should()
				.BeEquivalentTo(value.Key.Values);
		}

		[Fact]
		public void SetupClassWithBoolArraysBrackets()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { true, false }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var result = bool.Parse(
					section[$"{nameof(value.Key.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithBoolArraysBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { true, false }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var result = bool.Parse(
					fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableBoolArrays()
		{
			var value = new
			{
				Key = new
				{
					Values = new bool?[] { true, false, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			var result = section
				.GetSection(nameof(value.Key.Values))
				.Get<bool?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Key.Values);
		}

		[Fact]
		public void SetupClassWithNullableBoolArraysBrackets()
		{
			var value = new
			{
				Key = new
				{
					Values = new bool?[] { true, false, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var stringResult = section[$"{nameof(value.Key.Values)}:{i}"];

				var result = value.Key.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (bool?)null : throw new Exception(),
					_ => bool.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithBoolNullableArraysBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Values = new bool?[] { true, false, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Values)}:{i}"];

				var result = value.Key.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (bool?)null : throw new Exception(),
					_ => bool.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithByteArrays()
		{
			var value = new
			{
				Key = new
				{
					Values = new byte[] { 1, 2 }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			var result = section
				.GetSection(nameof(value.Key.Values))
				.Get<byte[]>();

			result
				.Should()
				.BeEquivalentTo(value.Key.Values);
		}

		[Fact]
		public void SetupClassWithByteArraysBrackets()
		{
			var value = new
			{
				Key = new
				{
					Values = new byte[] { 1, 2 }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var result = byte.Parse(
					section[$"{nameof(value.Key.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithByteArraysBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Values = new byte[] { 1, 2 }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var result = byte.Parse(
					fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableByteArrays()
		{
			var value = new
			{
				Key = new
				{
					Values = new byte?[] { 1, 2, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			var result = section
				.GetSection(nameof(value.Key.Values))
				.Get<byte?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Key.Values);
		}

		[Fact]
		public void SetupClassWithNullableByteArraysBrackets()
		{
			var value = new
			{
				Key = new
				{
					Values = new byte?[] { 1, 2, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var stringResult = section[$"{nameof(value.Key.Values)}:{i}"];

				var result = value.Key.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (byte?)null : throw new Exception(),
					_ => byte.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableByteArraysBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Values = new byte?[] { 1, 2, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Values)}:{i}"];

				var result = value.Key.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (byte?)null : throw new Exception(),
					_ => byte.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithSbyteArrays()
		{
			var value = new
			{
				Key = new
				{
					Values = new sbyte[] { 1, 2 }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			var result = section
				.GetSection(nameof(value.Key.Values))
				.Get<sbyte[]>();

			result
				.Should()
				.BeEquivalentTo(value.Key.Values);
		}

		[Fact]
		public void SetupClassWithSbyteArraysBrackets()
		{
			var value = new
			{
				Key = new
				{
					Values = new sbyte[] { 1, 2 }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var result = sbyte.Parse(
					section[$"{nameof(value.Key.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithSbyteArraysBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Values = new sbyte[] { 1, 2 }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var result = sbyte.Parse(
					fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableSbyteArrays()
		{
			var value = new
			{
				Key = new
				{
					Values = new sbyte?[] { 1, 2, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			var result = section
				.GetSection(nameof(value.Key.Values))
				.Get<sbyte?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Key.Values);
		}

		[Fact]
		public void SetupClassWithNullableSbyteArraysBrackets()
		{
			var value = new
			{
				Key = new
				{
					Values = new sbyte?[] { 1, 2, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var stringResult = section[$"{nameof(value.Key.Values)}:{i}"];

				var result = value.Key.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (sbyte?)null : throw new Exception(),
					_ => sbyte.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableSbyteArraysBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Values = new sbyte?[] { 1, 2, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);
			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Values)}:{i}"];

				var result = value.Key.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (sbyte?)null : throw new Exception(),
					_ => sbyte.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithCharArrays()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { '日', '本' }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			var result = section
				.GetSection(nameof(value.Key.Values))
				.Get<char[]>();

			result
				.Should()
				.BeEquivalentTo(value.Key.Values);
		}

		[Fact]
		public void SetupClassWithCharArraysBrackets()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { '日', '本' }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var result = char.Parse(
					section[$"{nameof(value.Key.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithCharArraysBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { '日', '本' }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var result = char.Parse(
					fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableCharArrays()
		{
			var value = new
			{
				Key = new
				{
					Values = new char?[] { '日', '本', null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			var result = section
				.GetSection(nameof(value.Key.Values))
				.Get<char?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Key.Values);
		}

		[Fact]
		public void SetupClassWithNullableCharArraysBrackets()
		{
			var value = new
			{
				Key = new
				{
					Values = new char?[] { '日', '本', null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var stringResult = section[$"{nameof(value.Key.Values)}:{i}"];

				var result = value.Key.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (char?)null : throw new Exception(),
					_ => char.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableCharArraysBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Values = new char?[] { '日', '本', null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Values)}:{i}"];

				var result = value.Key.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (char?)null : throw new Exception(),
					_ => char.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithDecimalArrays()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { 1.3m, 2.45m }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			var result = section
				.GetSection(nameof(value.Key.Values))
				.Get<decimal[]>();

			result
				.Should()
				.BeEquivalentTo(value.Key.Values);
		}

		[Fact]
		public void SetupClassWithDecimalArraysBrackets()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { 1.3m, 2.45m }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var result = decimal.Parse(
					section[$"{nameof(value.Key.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithDecimalArraysBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { 1.3m, 2.45m }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var result = decimal.Parse(
					fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableDecimalArrays()
		{
			var value = new
			{
				Key = new
				{
					Values = new decimal?[] { 1.3m, 2.45m, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			var result = section
				.GetSection(nameof(value.Key.Values))
				.Get<decimal?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Key.Values);
		}

		[Fact]
		public void SetupClassWithNullableDecimalArraysBrackets()
		{
			var value = new
			{
				Key = new
				{
					Values = new decimal?[] { 1.3m, 2.45m, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var stringResult = section[$"{nameof(value.Key.Values)}:{i}"];

				var result = value.Key.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (decimal?)null : throw new Exception(),
					_ => decimal.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableDecimalArraysBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Values = new decimal?[] { 1.3m, 2.45m, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Values)}:{i}"];

				var result = value.Key.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (decimal?)null : throw new Exception(),
					_ => decimal.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithDoubleArrays()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { 1.2d, 2.33d }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			var result = section
				.GetSection(nameof(value.Key.Values))
				.Get<double[]>();

			result
				.Should()
				.BeEquivalentTo(value.Key.Values);
		}

		[Fact]
		public void SetupClassWithDoubleArraysBrackets()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { 1.2d, 2.33d }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var result = double.Parse(
					section[$"{nameof(value.Key.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithDoubleArraysBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { 1.2d, 2.33d }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var result = double.Parse(
					fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableDoubleArrays()
		{
			var value = new
			{
				Key = new
				{
					Values = new double?[] { 1.2d, 2.33d, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			var result = section
				.GetSection(nameof(value.Key.Values))
				.Get<double?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Key.Values);
		}

		[Fact]
		public void SetupClassWithNullableDoubleArraysBrackets()
		{
			var value = new
			{
				Key = new
				{
					Values = new double?[] { 1.2d, 2.33d, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var stringResult = section[$"{nameof(value.Key.Values)}:{i}"];

				var result = value.Key.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (double?)null : throw new Exception(),
					_ => double.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableDoubleArraysBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Values = new double?[] { 1.2d, 2.33d, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Values)}:{i}"];

				var result = value.Key.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (double?)null : throw new Exception(),
					_ => double.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithFloatArrays()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { 1.2f, 2.33f }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			var result = section
				.GetSection(nameof(value.Key.Values))
				.Get<float[]>();

			result
				.Should()
				.BeEquivalentTo(value.Key.Values);
		}

		[Fact]
		public void SetupClassWithFloatArraysBrackets()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { 1.2f, 2.33f }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var result = float.Parse(
					section[$"{nameof(value.Key.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithFloatArraysBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { 1.2f, 2.33f }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var result = float.Parse(
					fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableFloatArrays()
		{
			var value = new
			{
				Key = new
				{
					Values = new float?[] { 1.2f, 2.33f, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			var result = section
				.GetSection(nameof(value.Key.Values))
				.Get<float?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Key.Values);
		}

		[Fact]
		public void SetupClassWithNullableFloatArraysBrackets()
		{
			var value = new
			{
				Key = new
				{
					Values = new float?[] { 1.2f, 2.33f, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var stringResult = section[$"{nameof(value.Key.Values)}:{i}"];

				var result = value.Key.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (float?)null : throw new Exception(),
					_ => float.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableFloatArraysBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Values = new float?[] { 1.2f, 2.33f, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Values)}:{i}"];

				var result = value.Key.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (float?)null : throw new Exception(),
					_ => float.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithIntArrays()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { 1, 2 }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			var result = section
				.GetSection(nameof(value.Key.Values))
				.Get<int[]>();

			result
				.Should()
				.BeEquivalentTo(value.Key.Values);
		}

		[Fact]
		public void SetupClassWithIntArraysBrackets()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { 1, 2 }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var result = int.Parse(
					section[$"{nameof(value.Key.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithIntArraysBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { 1, 2 }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var result = int.Parse(
					fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableIntArrays()
		{
			var value = new
			{
				Key = new
				{
					Values = new int?[] { 1, 2, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			var result = section
				.GetSection(nameof(value.Key.Values))
				.Get<int?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Key.Values);
		}

		[Fact]
		public void SetupClassWithNullableIntArraysBrackets()
		{
			var value = new
			{
				Key = new
				{
					Values = new int?[] { 1, 2, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var stringResult = section[$"{nameof(value.Key.Values)}:{i}"];

				var result = value.Key.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (int?)null : throw new Exception(),
					_ => int.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableIntArraysBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Values = new int?[] { 1, 2, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Values)}:{i}"];

				var result = value.Key.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (int?)null : throw new Exception(),
					_ => int.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithUintArrays()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { 1u, 2u }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			var result = section
				.GetSection(nameof(value.Key.Values))
				.Get<uint[]>();

			result
				.Should()
				.BeEquivalentTo(value.Key.Values);
		}

		[Fact]
		public void SetupClassWithUintArraysBrackets()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { 1u, 2u }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var result = uint.Parse(
					section[$"{nameof(value.Key.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithUintArraysBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { 1u, 2u }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var result = uint.Parse(
					fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableUintArrays()
		{
			var value = new
			{
				Key = new
				{
					Values = new uint?[] { 1u, 2u, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			var result = section
				.GetSection(nameof(value.Key.Values))
				.Get<uint?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Key.Values);
		}

		[Fact]
		public void SetupClassWithNullableUintArraysBrackets()
		{
			var value = new
			{
				Key = new
				{
					Values = new uint?[] { 1u, 2u, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var stringResult = section[$"{nameof(value.Key.Values)}:{i}"];

				var result = value.Key.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (uint?)null : throw new Exception(),
					_ => uint.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableUintArraysBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Values = new uint?[] { 1u, 2u, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Values)}:{i}"];

				var result = value.Key.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (uint?)null : throw new Exception(),
					_ => uint.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithLongArrays()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { 1L, 2L }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			var result = section
				.GetSection(nameof(value.Key.Values))
				.Get<long[]>();

			result
				.Should()
				.BeEquivalentTo(value.Key.Values);
		}

		[Fact]
		public void SetupClassWithLongArraysBrackets()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { 1L, 2L }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var result = long.Parse(
					section[$"{nameof(value.Key.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithLongArraysBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { 1L, 2L }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var result = long.Parse(
					fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithEnumLongArrays()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { LongEnum.Val1, LongEnum.Val2 }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			var result = section
				.GetSection(nameof(value.Key.Values))
				.Get<LongEnum[]>();

			result
				.Should()
				.BeEquivalentTo(value.Key.Values);
		}

		[Fact]
		public void SetupClassWithNullableLongArrays()
		{
			var value = new
			{
				Key = new
				{
					Values = new long?[] { 1L, 2L, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			var result = section
				.GetSection(nameof(value.Key.Values))
				.Get<long?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Key.Values);
		}

		[Fact]
		public void SetupClassWithNullableLongArraysBrackets()
		{
			var value = new
			{
				Key = new
				{
					Values = new long?[] { 1L, 2L, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var stringResult = section[$"{nameof(value.Key.Values)}:{i}"];

				var result = value.Key.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (long?)null : throw new Exception(),
					_ => long.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableLongArraysBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Values = new long?[] { 1L, 2L, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Values)}:{i}"];

				var result = value.Key.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (long?)null : throw new Exception(),
					_ => long.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithUlongArrays()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { 1UL, 2UL }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			var result = section
				.GetSection(nameof(value.Key.Values))
				.Get<ulong[]>();

			result
				.Should()
				.BeEquivalentTo(value.Key.Values);
		}

		[Fact]
		public void SetupClassWithUlongArraysBrackets()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { 1UL, 2UL }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var result = ulong.Parse(
					section[$"{nameof(value.Key.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithUlongArraysBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Values = new[] { 1UL, 2UL }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var result = ulong.Parse(
					fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableUlongArrays()
		{
			var value = new
			{
				Key = new
				{
					Values = new ulong?[] { 1UL, 2UL, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			var result = section
				.GetSection(nameof(value.Key.Values))
				.Get<ulong?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Key.Values);
		}

		[Fact]
		public void SetupClassWithNullableUlongArraysBrackets()
		{
			var value = new
			{
				Key = new
				{
					Values = new ulong?[] { 1UL, 2UL, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var stringResult = section[$"{nameof(value.Key.Values)}:{i}"];

				var result = value.Key.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (ulong?)null : throw new Exception(),
					_ => ulong.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableUlongArraysBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Values = new ulong?[] { 1UL, 2UL, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Values)}:{i}"];

				var result = value.Key.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (ulong?)null : throw new Exception(),
					_ => ulong.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithShortArrays()
		{
			var value = new
			{
				Key = new
				{
					Values = new short[] { 1, 2 }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			var result = section
				.GetSection(nameof(value.Key.Values))
				.Get<short[]>();

			result
				.Should()
				.BeEquivalentTo(value.Key.Values);
		}

		[Fact]
		public void SetupClassWithShortArraysBrackets()
		{
			var value = new
			{
				Key = new
				{
					Values = new short[] { 1, 2 }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var result = short.Parse(
					section[$"{nameof(value.Key.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithShortArraysBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Values = new short[] { 1, 2 }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var result = short.Parse(
					fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableShortArrays()
		{
			var value = new
			{
				Key = new
				{
					Values = new short?[] { 1, 2, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			var result = section
				.GetSection(nameof(value.Key.Values))
				.Get<short?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Key.Values);
		}

		[Fact]
		public void SetupClassWithNullableShortArraysBrackets()
		{
			var value = new
			{
				Key = new
				{
					Values = new short?[] { 1, 2, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var stringResult = section[$"{nameof(value.Key.Values)}:{i}"];

				var result = value.Key.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (short?)null : throw new Exception(),
					_ => short.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableShortArraysBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Values = new short?[] { 1, 2, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Values)}:{i}"];

				var result = value.Key.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (short?)null : throw new Exception(),
					_ => short.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithUshortArrays()
		{
			var value = new
			{
				Key = new
				{
					Values = new ushort[] { 1, 2 }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			var result = section
				.GetSection(nameof(value.Key.Values))
				.Get<ushort[]>();

			result
				.Should()
				.BeEquivalentTo(value.Key.Values);
		}

		[Fact]
		public void SetupClassWithUshortArraysBrackets()
		{
			var value = new
			{
				Key = new
				{
					Values = new ushort[] { 1, 2 }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var result = ushort.Parse(
					section[$"{nameof(value.Key.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithUshortArraysBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Values = new ushort[] { 1, 2 }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var result = ushort.Parse(
					fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Values)}:{i}"]);

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableUshortArrays()
		{
			var value = new
			{
				Key = new
				{
					Values = new ushort?[] { 1, 2, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			var result = section
				.GetSection(nameof(value.Key.Values))
				.Get<ushort?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Key.Values);
		}

		[Fact]
		public void SetupClassWithNullableUshortArraysBrackets()
		{
			var value = new
			{
				Key = new
				{
					Values = new ushort?[] { 1, 2, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Key));

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var stringResult = section[$"{nameof(value.Key.Values)}:{i}"];

				var result = value.Key.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (ushort?)null : throw new Exception(),
					_ => ushort.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}

		[Fact]
		public void SetupClassWithNullableUshortArraysBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Values = new ushort?[] { 1, 2, null }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Key.Values.Length; i++)
			{
				var stringResult = fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Values)}:{i}"];

				var result = value.Key.Values[i] switch
				{
					null => string.IsNullOrEmpty(stringResult) ? (ushort?)null : throw new Exception(),
					_ => ushort.Parse(stringResult)
				};

				result
					.Should()
					.Be(value.Key.Values[i]);
			}
		}
	}
}
