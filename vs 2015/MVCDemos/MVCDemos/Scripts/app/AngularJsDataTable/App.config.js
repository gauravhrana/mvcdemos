//angularJsDatatable.config(['$locationProvider', '$routeProvider',
//    function config($locationProvider, $routeProvider) {
//        $locationProvider.hashPrefix('!');

//        $routeProvider.
//        when('/home', {
//            templateUrl: '/app/views/home.html',
//            controller: 'BookController'
//        }).
//        otherwise('/home');

//    }
//]);


angularJsDatatable.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/home');

    $stateProvider
        // State managing 
        .state('home', {
            url: '/home',
            templateUrl: '/app/views/home.html',
            controller: 'BookController'
        })
         // nested list with data
        .state('home.template', {
            url: '/template',
            template: 'Welcome to the C# Corner'
        })

        // nested list with controller
        .state('home.list', {
            url: '/list',
            templateUrl: '/app/views/homelist.html',
            controller: function ($scope) {
                $scope.Language = ['C#', 'VB', 'JavaScript','PHP'];
            }
        })

        // State with multiple views
        .state('multipleview', {
            url: '/multipleview',
            views: {
                '': { templateUrl: '/app/views/multipleview.html' },
                'ViewOne@multipleview': { template: 'Welcome to the C# Corner!' },
                'ViewTwo@multipleview': {
                    templateUrl: '/App/Test/dataList.html',
                    controller: 'CarController'
                },
                'ViewThree@multipleview': {
                    templateUrl: '/app/views/homelist.html',
                    controller: function ($scope) {
                        $scope.Language = ['C#', 'VB', 'JavaScript', 'PHP'];
                    }
                }

            }

        });

});

