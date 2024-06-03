using NUnit.Framework;
using ECommerceApp;
using System;

namespace ECommerceApp.Tests
{
	[TestFixture]
	public class ProductTests
	{
		[Test]
		public void Constructor_ValidInput_ShouldSetProperties()
		{
			// Arrange & Act
			var product = new Product(1, "Test Product", 9.99m, 100);

			// Assert
			Assert.That(product.ProductID, Is.EqualTo(1));
			Assert.That(product.ProductName, Is.EqualTo("Test Product"));
			Assert.That(product.Price, Is.EqualTo(9.99m));
			Assert.That(product.Stock, Is.EqualTo(100));
		}

		[Test]
		public void Constructor_InvalidProductID_ShouldThrowException()
		{
			// Arrange, Act & Assert
			Assert.That(() => new Product(0, "Test Product", 9.99m, 100), Throws.TypeOf<ArgumentOutOfRangeException>());
		}

		[Test]
		public void Constructor_InvalidPrice_ShouldThrowException()
		{
			// Arrange, Act & Assert
			Assert.That(() => new Product(1, "Test Product", 0, 100), Throws.TypeOf<ArgumentOutOfRangeException>());
		}

		[Test]
		public void Constructor_InvalidStock_ShouldThrowException()
		{
			// Arrange, Act & Assert
			Assert.That(() => new Product(1, "Test Product", 9.99m, 0), Throws.TypeOf<ArgumentOutOfRangeException>());
		}

		[Test]
		public void IncreaseStock_ValidAmount_ShouldIncreaseStock()
		{
			// Arrange
			var product = new Product(1, "Test Product", 9.99m, 100);

			// Act
			product.IncreaseStock(50);

			// Assert
			Assert.That(product.Stock, Is.EqualTo(150));
		}

		[Test]
		public void IncreaseStock_InvalidAmount_ShouldThrowException()
		{
			// Arrange
			var product = new Product(1, "Test Product", 9.99m, 100);

			// Act & Assert
			Assert.That(() => product.IncreaseStock(-10), Throws.TypeOf<ArgumentOutOfRangeException>());
		}

		[Test]
		public void DecreaseStock_ValidAmount_ShouldDecreaseStock()
		{
			// Arrange
			var product = new Product(1, "Test Product", 9.99m, 100);

			// Act
			product.DecreaseStock(50);

			// Assert
			Assert.That(product.Stock, Is.EqualTo(50));
		}

		[Test]
		public void DecreaseStock_InvalidAmount_ShouldThrowException()
		{
			// Arrange
			var product = new Product(1, "Test Product", 9.99m, 100);

			// Act & Assert
			Assert.That(() => product.DecreaseStock(-10), Throws.TypeOf<ArgumentOutOfRangeException>());
		}

		[Test]
		public void DecreaseStock_AmountGreaterThanStock_ShouldThrowException()
		{
			// Arrange
			var product = new Product(1, "Test Product", 9.99m, 100);

			// Act & Assert
			Assert.That(() => product.DecreaseStock(200), Throws.TypeOf<InvalidOperationException>());
		}

		[Test]
		public void DecreaseStock_AmountEqualToStock_ShouldSetStockToZero()
		{
			// Arrange
			var product = new Product(1, "Test Product", 9.99m, 100);

			// Act
			product.DecreaseStock(100);

			// Assert
			Assert.That(product.Stock, Is.EqualTo(0));
		}

		[Test]
		public void DecreaseStock_AmountLessThanStock_ShouldNotThrowException()
		{
			// Arrange
			var product = new Product(1, "Test Product", 9.99m, 100);

			// Act & Assert
			Assert.That(() => product.DecreaseStock(50), Throws.Nothing);
		}

		[Test]
		public void DecreaseStock_AmountEqualToZero_ShouldNotChangeStock()
		{
			// Arrange
			var product = new Product(1, "Test Product", 9.99m, 100);
			int initialStock = product.Stock;

			// Act
			product.DecreaseStock(0);

			// Assert
			Assert.That(product.Stock, Is.EqualTo(initialStock));
		}
	}
}
