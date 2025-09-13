using MediatR;
using Moq;
using Netrilo.Infrastructure.Common.Abstractions.Events;

namespace Netrilo.Infrastructure.Common.Bus.UnitTests.Mediator
{
    public class RequestHandlerUnitTests
    {
        // init
        class TestRequest : IRequest<TestResponse>
        {
            public Guid Id { get; init; }
        }
        class TestResponse
        {
            public Guid Id { get; init; }
        }

        class TestEvent : IEvent
        { }

        class TestRequestHandler(IMediator mediator) : IRequestHandler<TestRequest, TestResponse>
        {
            public IMediator Mediator { get; set; } = mediator;

            public async Task<TestResponse> Handle(TestRequest request, CancellationToken cancellationToken)
            {
                //do some stuff

                await Mediator.Publish(new TestEvent(), cancellationToken);
                return new TestResponse() { Id = request.Id };
            }
        }

        [Fact]
        public async Task Check_Binded_Request_Handler_Is_Valid()
        {
            //Arrange
            var mediator = new Mock<IMediator>();

            Guid id = Guid.NewGuid();
            TestRequest command = new() { Id = id };
            TestRequestHandler handler = new(mediator.Object);

            //Act
            TestResponse x = await handler.Handle(command, new CancellationToken());

            //Assert
            Assert.NotNull(x);
            Assert.Equal(id, x.Id);
        }
    }
}