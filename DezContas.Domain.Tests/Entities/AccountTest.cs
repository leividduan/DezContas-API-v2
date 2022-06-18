﻿using DezContas.Domain.Entities;
using System;
using Xunit;

namespace DezContas.Domain.Tests.Entities
{
	public class AccountTest
	{
		[Fact]
		[Trait("Account", "Create")]
		public void Account_Create_Successfully()
		{
			// Arrange
			var account = new Account("Banco X", "Conta do banco X pra movimentar o caixa 2", true, true, Domain.Entities.Type.General, Guid.NewGuid());

			// Act - Assert
			Assert.True(account.IsValid());
		}

		[Fact]
		[Trait("Account", "Create")]
		public void Account_Create_WithoutName()
		{
			// Arrange
			var account = new Account(string.Empty, "Conta do banco X pra movimentar o caixa 2", true, true, Domain.Entities.Type.General, Guid.NewGuid());

			// Act - Assert
			Assert.False(account.IsValid());
		}

		[Fact]
		[Trait("Account", "Create")]
		public void Account_Create_WithoutDescription()
		{
			// Arrange
			var account = new Account("Banco X", string.Empty, true, true, Domain.Entities.Type.General, Guid.NewGuid());

			// Act - Assert
			Assert.True(account.IsValid());
		}

		[Fact]
		[Trait("Account", "Create")]
		public void Account_Create_WithNameGreaterThanLimit()
		{
			// Arrange
			var name = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vestibulum odio et ultricies efficitur. In vel ullamcorper eros. Morbi elit magna, volutpat vulputate";
			var account = new Account(name, string.Empty, true, true, Domain.Entities.Type.General, Guid.NewGuid());

			// Act - Assert
			Assert.False(account.IsValid());
		}

		[Fact]
		[Trait("Account", "Create")]
		public void Account_Create_WithDescriptionGreaterThanLimit()
		{
			// Arrange
			var description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vestibulum odio et ultricies efficitur. In vel ullamcorper eros. Morbi elit magna, volutpat vulputate orci et, aliquet feugiat augue. Aliquam ut lorem egestas nulla posuere laoreet. Sed blandit elit lorem, id interdum mi vestibulum vel. Maecenas tristique porttitor lorem sit amet tincidunt. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Cras in ullamcorper leo, ut imperdiet lectus efficiturr.";
			var account = new Account("Banco X", description, true, true, Domain.Entities.Type.General, Guid.NewGuid());

			// Act - Assert
			Assert.False(account.IsValid());
		}
	}
}
