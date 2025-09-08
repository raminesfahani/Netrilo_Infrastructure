namespace Infrastructure.Common.Abstractions.Dto
{
    public class BaseDto<T>
    {
        public required T Id { get; set; }
    }

}
