"use strict"
var books = books || (function () {
    function onSuccessCreate() {
        location.reload();
    }

    function onFailedCreate(xhr) {
        if (xhr.status === 400) {
            document.getElementById('modal-container').innerHTML = xhr;
        } else {
            alert("Ocurrio un error al crear una persona");
        }
    }
    function showModal() {
        let modal = new bootstrap.Modal(document.querySelector('.modal'));
        $('.datepicker').datetimepicker({
            format: 'YYYY-MM-DD',
            viewMode: "years",
            icons: {
                time: 'bi bi-clock',
                date: 'bi bi-calendar',
                up: 'bi bi-arrow-up',
                down: 'bi bi-arrow-down',
                previous: 'bi bi-arrow-left',
                next: 'bi bi-arrow-right',
                today: 'bi bi-pin',
                clear: 'bi bi-trash',
                close: 'bi bi-cancel'
            }
        });
        modal.show();
    }
    function showAddBookModal() {
        fetch('/books/create')
            .then(response => {
                if (!response.ok) {
                    throw new Error('Error en la solicitud');
                }

                return response.text();
            })
            .then(html => {
                document.getElementById('modal-container').innerHTML = html;
                let modal = new bootstrap.Modal(document.getElementById('book-form-modal-js'));
                $('#releaseDateInput').on('keydown', function (e) {
                    e.preventDefault();
                });
                $.validator.unobtrusive.parse('#book-form');
                $(document).on('click', '#js-submit-form-button', function () {
                    let form = $(document.getElementById('book-form'));
                    if (!form.valid()) {
                        return;
                    }
                    $(form).submit();
                })
                showModal();

            })
            .catch(error => {
                console.error('Error:', error);
            });
    }
    function showEditModal() {
        $('#releaseDateInput').on('keydown', function (e) {
            e.preventDefault();
        });

        $.validator.unobtrusive.parse('#book-form');
        $(document).on('click', '#js-submit-form-button', function () {
            let form = $(document.getElementById('book-form'));
            if (!form.valid()) {
                return;
            }
            $(form).submit();
        })
        showModal();
    }

    function addEventListeners() {
        $(document).on('click', '#btn-add-js', showAddBookModal);
    }
    function initDataTable() {
        $('#table-books-js').DataTable({
            searching: false,
            lengthChange: false
        });
    }
    function init() {
        addEventListeners();
        initDataTable();
    }


    return {
        init: init,
        onSuccessCreate,
        onFailedCreate,
        showModal,
        showEditModal
    }
})();