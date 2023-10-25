# MovieAPI

MovieAPI is an API project to developed for educational purposes and similar to the API used by TMDB. 
TMDB stands for "The Movie Database" which built as user editable movie and TV database and has also an API.


<br>

I have created a scenario to reinforce what I have learned. It will work similarly to the API developed by TMDB. My API will provide information about movies, including details about the movie's budget, information about the actors appearing in the movie, the genres in which the actors have played or vice versa and even more data.
This JSON data is eligible to be consumed by various front end technologies such as mobile apps, Angular, Vue.js, React etc. or another API.

<br>

* The software was written in C#
* ASP.NET Web API framework was used to create a Restful Api.
* CLEAN Code Techniques and SOLID Principles was followed during development process.

<br>
<hr>
<br>

# Software Design

### Arhitecture
N Tier Architecture has been impelemented.

### Database
PostgreSQL was used as database. Triggers has been also added from migrations.

### Global Exception Handler
Global exception handling middleware was added to centralize exception handling. Custom Exceptions was created.

### Aspect Oriented Programming
To exceed seperation of cross cutting concers from the existed service logic, aspect oriented programming is a well-known technique.
Interceptors was used to clearize service logic from the cross cutting concerns. Concers was thought and applied as aspect attributes

Although Log Aspect and Cache Aspect was initially implemented initially, Other Aspect could be added easily into existed structure.

<br>
<hr>
<br>


## Technologies & Tools

<ul>
  <li>
    <h3>Serilog</h3>
    <p><strong>Serilog</strong> was used as Logger. The logger could be used alone or as an aspect both. Global Exception Handling also has includes logging.</p>
  </li>
  <li>
    <h3>SEQ</h3>
    <p>Logging is an effective way to manage the monitoring, troubleshooting, and debugging process. However, when it's used directly and single-handedly the management will be rough to overcome. <strong>SEQ</strong> is a self-hosted search, analysis, and alerting server built for structured log data.</p>
    <p>Exception Handler, Logger, and <strong>SEQ</strong> work in collaboration.</p>
  </li>
  <li>
    <h3>Redis</h3>
    <p><strong>Redis</strong> was used as a distributed cache for caching. Rate Limiting also configured to use Redis as store rates.</p>
  </li>
  <li>
    <h3>Rate Limiting</h3>
    <p><strong>AspNetCoreRateLimit</strong> package was used for IP Rate Limiting.</p>
  </li>
  <li>
    <h3>JSON Web Token & Refresh Token</h3>
    <p>JWT was used for authentication, refresh token mechanism has also been implemented.</p>
  </li>
  <li>
    <h3>ASP.NET Identity</h3>
    <p><strong>ASP.NET Identity</strong> is an API which could manages users, passwords, roles, claims, tokens, email confirmation, and more.</p>
  </li>
  <li>
    <h3>Autofac DI Container</h3>
    <p><strong>Autofac</strong> works as IoC container and The Autofac.Extras.DynamicProxy integration package enables method calls on Autofac components to be intercepted by other components. </p>
  </li>
</ul>










