//Testing GET for http://localhost:5003/gateway/order

//Request method is equal to GET
pm.test("Request is GET", () => {
    pm.expect(pm.request.method).to.be.equal("GET");
});

//Response status code
pm.test("Response code should be 200", () => {
    pm.response.to.have.status(200);
});

//Response body is json
pm.test("Response body is correct", () => {
    pm.response.to.be.json;
});

//Check if object has expected content
//This test can only be passed if response body is not null 
pm.test("Test if object contains property", function () {
    var jsonData = pm.response.text();
    pm.expect(jsonData).to.contain("id");
    pm.expect(jsonData).to.contain("product");
});

//Response time
pm.test("Response time is less than 200ms", () => {
    pm.expect(pm.response.responseTime).to.be.below(200);
});
