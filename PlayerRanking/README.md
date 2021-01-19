How I considered usage volume:
- I found this step to be a little challenging. I have limited experience designing entire web apps with high usage volume in mind (we have a redis server for caching, but our devOps engineers have more experience with it than myself/others).
- One way I thought to improve performance (especially when there's high usage) was to add caching when calling the ATP APIs.
- I used ASP.Net Core InMemory caching to do this.
- I used a combination of sliding and absolute expiration times on cached services to prevent stale data.

Tech used:
- I decided to create a Blazor application. I've always wanted to experiment with Blazor, and this seemed like the perfect opportunity to do so, given the .Net 5 requirement.
- I used Newtonsoft JSON to deserialize reponses from the ATP APIs.
- I also used Blazorise. It's a free Blazor component library that I think looks pretty sleek. I find these sorts of libraries to be very helpful in prototyping/rapid development.
- I believe everything else is just out of the box .NET 5.

Overall... I thought this was a fun small project!

Anyways... here ya go ¯\_(ツ)_/¯