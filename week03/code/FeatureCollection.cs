
    public class FeatureCollection {
    // Todo Earthquake Problem - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public List<Feature> Features { get; set; }
}
public class Feature
{
    public string Id { get; set; }
    public FeatureProperties Properties { get; set; }
}
public class FeatureProperties
{
    public string Place { get; set; }
    public decimal Mag { get; set; }
}
}
