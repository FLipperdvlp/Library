import { useEffect, useState } from "react";
import authorsService from "./api/authorsService";
import AuthorForm from "./components/AuthorForm/AuthorForm";
import AuthorCard from "./components/AuthorCard/AuthorCard";

function App() {
  const [authors, setAuthors] = useState([]);

  const loadAuthors = async () => {
    try {
      const res = await authorsService.getAll();
      setAuthors(res.data);
    } catch (err) {
      console.error("Помилка завантаження авторів:", err);
    }
  };

  const deleteAuthor = async (id) => {
    try {
      await authorsService.delete(id);
      loadAuthors(); 
    } catch (err) {
      console.error("Помилка при видаленні:", err);
    }
  };

  useEffect(() => {
    loadAuthors();
  }, []);

  return (
    <div style={{ padding: "20px" }}>
      <h1>Список авторів</h1>
      <AuthorForm onAuthorCreated={loadAuthors} />

      <div style={{ display: "flex", flexWrap: "wrap", gap: "20px" }}>
        {authors.length === 0 ? (
          <p>Авторів поки що немає.</p>
        ) : (
          authors.map((author) => (
            <AuthorCard
              key={author.id}
              author={author}
              onDelete={deleteAuthor}
            />
          ))
        )}
      </div>
    </div>
  );
}

export default App;