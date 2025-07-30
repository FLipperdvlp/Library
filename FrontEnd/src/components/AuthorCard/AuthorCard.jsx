import React from "react";
import styles from "./AuthorCard.module.css";

const AuthorCard = ({ author, onDelete }) => {
  const { name, deathDate, createdAt, updatedAt, id } = author;

  const formatDate = (dateString) =>
    new Date(dateString).toLocaleDateString("en-GB", {
      year: "numeric",
      month: "long",
      day: "numeric",
    });

  return (
    <div className={styles.card}>
      <h2 className={styles.name}>{name}</h2>
      <p className={styles.detail}>
        <strong>Дата смерті:</strong> {formatDate(deathDate)}
      </p>
      <div className={styles.meta}>
        <p>Створено: {formatDate(createdAt)}</p>
        <p>Оновлено: {formatDate(updatedAt)}</p>
      </div>
      <button onClick={() => onDelete(id)}>Видалити</button>
    </div>
  );
};

export default AuthorCard;
