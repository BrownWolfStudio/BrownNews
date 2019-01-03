// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
navigator.serviceWorker.getRegistrations().then(

    function(registrations) {

        for(let registration of registrations) { 

            registration.unregister()
            .then(function() {

              return self.clients.matchAll();

            })
         .then(function(clients) {

              clients.forEach(client => {

            if (client.url && "navigate" in client){

                client.navigate(client.url));

            }

         });

        }

});
