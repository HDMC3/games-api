namespace Aplication.Exceptions;

public class QueryException : Exception {
    public QueryException() : base() {}

    public QueryException(string message) : base(message) {}
}