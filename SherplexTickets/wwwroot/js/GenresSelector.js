
    function updateGenreIds() {
        var selectedGenreIds = [];
    // Изберете всички избрани чекбоксове
    document.querySelectorAll('input[name="GenreIds"]:checked').forEach(function (checkbox) {
        selectedGenreIds.push(parseInt(checkbox.value)); // Добавете идентификаторите на избраните жанрове
        });
    // Присвояване на стойността на GenreIds модела
    document.querySelector('input[name="GenreIds"]').value = selectedGenreIds.join(','); // Съединяване на избраните идентификатори в стринг, разделени със запетаи
    }

    // Слушател за събитие за промяна на състоянието на чекбокса
    document.querySelectorAll('input[name="GenreIds"]').forEach(function (checkbox) {
        checkbox.addEventListener('change', updateGenreIds); // Актуализирайте GenreIds модела, когато се промени изборът
    });

