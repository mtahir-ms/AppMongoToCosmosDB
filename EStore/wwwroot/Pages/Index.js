$(document).ready(async function () {
    product();
})
function product() {
    $.ajax({
        type: "GET",
        url: "/Home/Products",
        success: function (result) {
            debugger
            if (Array.isArray(result) && result.length > 0) {
                var div = '';
                result.forEach(function (product) {
                    debugger
                    div += `      <div class="col mb-5">`;
                    div += `         <div class="card h-100">`;
                    div += `             <img class="card-img-top" src="${product.Image}" alt="..."  />`;
                    div += `             <div class="card-body p-4">`;
                    div += `                 <div class="text-center">`;
                    div += `                     <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Product"> `;
                    div += `                         <h5 class="fw-bolder">${product.ProductName}</h5></a>`;
                    div += `                         <span>${product.Price}</span>`;
                    div += `                 </div>`;
                    div += `             </div>`;
                    div += `             <div class="card-footer p-4 pt-0 border-top-0 bg-transparent">`;
                    div += `                 <div class="text-center"><a class="btn btn-outline-dark mt-auto" href="#">View options</a></div>`;
                    div += `             </div>`;
                    div += `         </div>`;
                    div += `     </div> `;

                    //var productDiv = $('<div class="col mb-5">')
                    //    .append($('<div class="card h-100">')
                    //     //   .append($('<img class="card-img-top" src="' + product.ImageSrc + '" alt="..."/>'))
                    //        .append($('<img class="card-img-top" src="/assests/img1.png" alt="..."/>'))
                    //        .append($('<div class="card-body p-4">')
                    //            .append($('<div class="text-center">')
                    //                .append($('<a class="nav-link text-dark" href="#">')
                    //                    .append($('<h5 class="fw-bolder">').text(product.ProductName)))
                    //                .append($('<span>').text(product.Price))
                    //            )
                    //        )
                    //        .append($('<div class="card-footer p-4 pt-0 border-top-0 bg-transparent">')
                    //            .append($('<div class="text-center">')
                    //                .append($('<a class="btn btn-outline-dark mt-auto" href="#">View options</a>'))
                    //            )
                    //        )
                    //    );
                    //container.append(productDiv);
                });
                $("#ProductDiv").html(div);

                console.log(result);
            } else {
                console.error("No products found.");
            }
        },
    });
}









function producttt() {

    $.ajax({
        type: "GET",
        url: "/Home/Products",
        success: function (result) {

            debugger
            //  var Product= $('#Product').val(result.ProductName);
            if (Array.isArray(result) && result.length > 0) {
                // Display the first product's name in the #Product element
                //$('#Product').text(result[0].ProductName);
                //$('#Price').text(result[0].price);

                $('<div class="col mb-5">')
                    .append($('<div class="card h-100">')
                        .append($('<img class="card-img-top" src="' + product.ImageSrc + '" alt="..."/>'))
                        .append($('<div class="card-body p-4">')
                            .append($('<div class="text-center">')
                                .append($('<a class="nav-link text-dark" href="#">')
                                    .append($('<h5 class="fw-bolder">').text(result[0].ProductName)))
                                .append($('<span>').text(result[0].price))
                            )
                        )
                        .append($('<div class="card-footer p-4 pt-0 border-top-0 bg-transparent">')
                            .append($('<div class="text-center">')
                                .append($('<a class="btn btn-outline-dark mt-auto" href="#">View options</a>'))
                            )
                        )
                    );

                console.log(result);
            } else {
                console.error("No products found.");
            }

            console.log(result);
        },

    });
}
