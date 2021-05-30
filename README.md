# SEOResultChecker

An application to check the ranks of target keyword in the Google search result

<b>Projects</b>
<ul style=list-style-position:inside;">
    <li>SEOResultChecker.Core   -   contains DTOs</li>
    <li>SEOResultChecker.DomainLogic -  ParseEngine and core logic</li>
    <li>SEOResultChecker.UnitTest  -   Unit test project</li>
    <li>SEOResultChecker.Service   -   proxy to call Google and uses parser to generate the results</li>
    <li>SEOResultChecker.Service.IntegrationTest   -   integration tests for end-to-end</li>
    <li>SEOResultChecker.UI   -   .NET core WPF client</li>
</ul>

<b>Approaches</b><br />
<ol style=list-style-position:inside;">
    <li>define the DTO used</li>
    <li>Used TDD for the ParseEngine and saved the html response from Google to limit the number of requests to their server. It appears that they have a daily limit. </li>
    <li>set up the WPF client for input/output</li>
    <li>set up the service layer to wire up the parsing logic and http request to search engine</li>
    <li>sanity check the solution from UI</li>
</ol>

<b>Features</b>
<ul style=list-style-position:inside;">
    <li>layered approach</li>
    <li>Caliburn.Micro in the WPF to facilitate MVVM design pattern. plus bundled simple DI container</li>
    <li>unit/integration tests project for the parsing logic and integration from the front end</li>
</ul>

<b>How to run</b>
build and run SEOResultChecker.UI

<b>Future enhancements</b>
<ul style=list-style-position:inside;">
    <li>service related projects can be pushed to server side (i.e. WebApi) to loose the dependency from UI to the service. there is no real urgency for the current requirements</li>
    <li>change to async on the UI interactions; review and clean up the xaml</li>
    <li>review the parser logic and make it more error prone or use 3rd party parser or APIs</li>
</ul>
