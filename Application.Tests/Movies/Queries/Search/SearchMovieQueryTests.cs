using Application.Movies;
using Application.Movies.Queries.Search;
using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using FluentAssertions;
using System.Linq;

namespace Application.Tests.Movies.Queries.Search
{
    [TestClass]
    public class SearchMovieQueryTests
    {
        [TestMethod]
        public void ReturnsListAsExpected()
        {
            var fixture = new Fixture();

            var expected = fixture.Create<SearchListItemModel>();
            var searchString = fixture.Create<string>();
            var movieRepository = new Mock<IMovieRepository>();
            movieRepository
                .Setup(mr => mr.Search(searchString))
                .Returns(new List<Movie> { new Movie { Title = expected.Title, Id = expected.Id } });

            var sut = new SearchMovieQuery(movieRepository.Object);

            var result = sut.Execute(searchString);

            result.Should().HaveCount(1);
            result.First().Should().BeEquivalentTo(expected);
        }
    }
}