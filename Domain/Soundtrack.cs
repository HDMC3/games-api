namespace Domain;

public class Soundtrack {
    protected Soundtrack() {}
    public int Id { get; private set; }
    public string Web { get; set; }

    public Soundtrack(string web) {
        Web = web;
    }
}