<div class="container">
	<div class="section white-section">
		<div class="profile-wrapper">
			<div class="row">
				<div class="col-sm-12">
					<h2>Данные о переводе</h2>

					<div class="row">
						<div class="col-sm-6">
							<br>
							<div><b>Название: </b> <?= $model['translation']->name?></div>
			        <div><b>Оригинальное название: </b> <?= $model['translation']->name_original?></div>
			        <div><b>from_language_id</b> <?= $model['translation']->from_language_id?></div>
			        <div><b>to_language_id</b> <?= $model['translation']->to_language_id?></div>
			        <div><b>cover_link</b> <?= $model['translation']->cover_link?></div>
			        <div><b>is_private</b> <?= $model['translation']->is_private?></div>
			        <div><b>is_finished</b> <?= $model['translation']->is_finished?></div>
			        <div><b>category_id</b> <?= $model['translation']->category_id?></div>
			        <div><b>creator_id</b> <?= $model['translation']->creator_id?></div>
							<br>
							<br>

			        <div><b>translation_id</b> <?=$model['translationBook']->translation_id?></div>
			        <div><b>author_name</b> <?=$model['translationBook']->author_name?></div>
			        <div><b>author_original_name</b> <?=$model['translationBook']->author_original_name?></div>
			        <div><b>year</b> <?=$model['translationBook']->year?></div>
						</div>
						<div class="col-sm-6">
						<?php $i = 1; ?>
						<?php foreach ($model['partsText'] as $part): ?>
							<h3>Часть <?= $i ?></h3>
							<?php $j = 1; ?>
							<?php foreach ($part as $fragment): ?>
								<b>Фрагмент <?=$j ?></b>
								<br>
								<p><?= $fragment['original_text'] ?></p>
								<?php $j++; ?>
							<?php endforeach; ?>
							<?php $i++; ?>
						<?php endforeach; ?>
							
						</div>
					</div>

					
					<br>
					<a class="btn btn-default btn-md" href="/translation/creation/fragmentation">Назад</a>&nbsp;
				    <a class="btn btn-success btn-md" href="/translation/workarea">Далее</a>
				</div>
			</div>
		</div>
	</div>
</div>
