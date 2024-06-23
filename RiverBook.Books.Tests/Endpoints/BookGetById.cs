using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using RiverBooks.Books;
using RiverBooks.Books.BookEndpoints;
using Xunit.Abstractions;

namespace RiverBook.Books.Tests.Endpoints;
public class BookGetById(Fixture fixture, ITestOutputHelper outputHelper):
  TestClass<Fixture>(fixture, outputHelper)
{
  [Theory]
  [InlineData("a89f6cd7-4693-457b-9009-02205dbbfe45", "The Fellowship of the Ring")]
  public async Task ReturnExpectedBookGivenIdAsync(string validId, string expectedTitle)
  {
    Guid id = Guid.Parse(validId);
    var request = new GetBookByIdRequest { Id = id };
    var testResult = await 
      Fixture.Client.GETAsync<GetById, GetBookByIdRequest,BookDto>(request);

    testResult.Response.EnsureSuccessStatusCode();
    testResult.Result.Title.Should().Be(expectedTitle);
  }
}

