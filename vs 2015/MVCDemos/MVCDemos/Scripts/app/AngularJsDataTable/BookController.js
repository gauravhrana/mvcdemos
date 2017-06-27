

angularJsDatatable.controller('BookController', function ($scope, BookService) {

    $scope.loadTable = function () {
        console.log('Loading 1');
        var Param = {};
        var ServiceData = BookService.loadGrid(Param);
        console.log('Loading 2')
        ServiceData.then(function (result) {
            $scope.LoadData = result.data;
        }, function () {
        });
    }

    $scope.loadTable();

    $scope.LoadById = function (model) {
        $scope.Ed = model;
        $scope.Datamode = 'Update';
        $scope.Enable = true;
    }

    $scope.Save = function () {
        if ($scope.Datamode === 'Update') {
            var Param = {
                BookId: $scope.Ed.BookId,
                BookCode: $scope.Ed.BookCode,
                BookName: $scope.Ed.BookName,
                BookDesc: $scope.Ed.BookDesc,
                BookAuthor: $scope.Ed.BookAuthor
            }
        }

        else {
            var Param = {
                BookId: $scope.Ed.BookId,
                BookCode: $scope.Ed.BookCode,
                BookName: $scope.Ed.BookName,
                BookDesc: $scope.Ed.BookDesc,
                BookAuthor: $scope.Ed.BookAuthor
            }
        }
        var ServiceData = BookService.EditData(Param);
        ServiceData.then(function (result) {
            $scope.loadTable()
            $scope.Ed = '';
            $scope.message = "Data Save Successfully";
        }, function () {

        });
    }

    $scope.DaleteById = function (model) {
        $scope.Ed = model;
        var Param = {
            BookId: $scope.Ed.BookId,
            BookCode: $scope.Ed.BookCode,
            BookName: $scope.Ed.BookName,
            BookDesc: $scope.Ed.BookDesc,
            BookAuthor: $scope.Ed.BookAuthor
        }
        var ServiceData = BookService.RemoveData(Param);
        ServiceData.then(function (result) {
            $scope.loadTable()
            $scope.Ed = '';
            $scope.message = "Data deleted Successfully";
        }, function () {

        });

    }

    $scope.Clear = function () {
        $scope.Ed = '';
        $scope.Enable = false;
        $scope.Datamode = '';
    }

});

angularJsDatatable.service('BookService', function ($http) {

    this.loadGrid = function (Param) {
        var response = $http({
            method: "post",
            url: "/Data/LoadAngularJsDataTableData",
            data: JSON.stringify(Param),
            dataType: "json"
        });
        return response;
    }

    this.EditData = function (Param) {
        var response = $http({
            method: "post",
            url: "/Data/EditAngularJsDataTableData",
            data: JSON.stringify(Param),
            dataType: "json"
        });
        return response;
    }

    this.RemoveData = function (param) {
        var response = $http({
            method: 'post',
            url: '/data/DeleteAngularJsDataTableData',
            data: JSON.stringify(param),
            dataType: 'json'
        })
        return response;
    }

});

