//Testing POST for http://localhost:5003/gateway/pizza

//Request method is equal to POST
pm.test("Request is POST", () => {
    pm.expect(pm.request.method).to.be.equal("POST");
});

//Response status code
pm.test("Response code should be 200", () => {
    pm.response.to.have.status(200);
});

//Response time
pm.test("Response time is less than 200ms", () => {
    pm.expect(pm.response.responseTime).to.be.below(200);
});


////  Example body for test purposes

//{
//    "id": 0,
//    "name": "Kebab",
//    "ingredients": "Kebab, pommes, kebabsås, sallad",
//    "price": 89
//}