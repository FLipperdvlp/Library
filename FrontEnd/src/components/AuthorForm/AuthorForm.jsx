import { useState } from "react";
import authorsService from "/Front/FrontEnd/src/api/authorsService";

export default function AuthorForm({ onAuthorCreated }) {
  const [name, setName] = useState("");
  const [deathDate, setDeathDate] = useState("");

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!name || !deathDate) return;

    try {
      await authorsService.create(name, deathDate);
      setName("");
      setDeathDate("");
      onAuthorCreated(); 
    } catch (error) {
      console.error("Помилка при створенні автора:", error);
    }
  };

  return (
    <form onSubmit={handleSubmit} style={{ marginBottom: "20px" }}>
      <h2>Додати нового автора</h2>
      <input
        type="text"
        placeholder="Ім'я автора"
        value={name}
        onChange={(e) => setName(e.target.value)}
        required
      />
      <input
        type="date"
        value={deathDate}
        onChange={(e) => setDeathDate(e.target.value)}
        required
      />
      <button type="submit">Додати автора</button>
    </form>
  );
}