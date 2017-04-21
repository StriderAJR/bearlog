<div class="container">
	<div class="section white-section">
		<div class="profile-wrapper">
			<div class="row">
				<div class="col-sm-12">
					<h2>Данные о переводе</h2>

					<div class="row translation-data-page">
						<div class="col-sm-6">
							<br>

							<div class="table-responsive">
								<img src="<?=$model['translation']->cover_link?>" class="cover-img img-responsive img-thumbnail" alt="">
							  <table class="table table-striped table-bordered table-hover">
									<tr><td><b>Название: </b></td><td> <?= $model['translation']->name?></td></tr>
					        <tr><td><b>Оригинальное название: </b></td><td> <?= $model['translation']->name_original?></td></tr>
					        <tr><td><b>Категория: </b></td><td>Книги</td></tr>
					        <tr><td><b>Имя автора: </b></td><td> <?=$model['translationBook']->author_name?></td></tr>
					        <tr><td><b>Имя автора на оригинальном языке: </b></td><td> <?=$model['translationBook']->author_original_name?></td></tr>
					        <tr><td><b>Год издания: </b></td><td> <?=$model['translationBook']->year?></td></tr>
					        <tr><td><b>Язык оригинала: </b></td><td> <?= $model['translation']->from_language_id?></td></tr>
					        <tr><td><b>Язык перевода: </b></td><td> <?= $model['translation']->to_language_id?></td></tr>
					        <tr><td><b>Приватный перевод: </b></td><td>
					        	<?php if ($model['translation']->is_private): ?>
						        	<i class="fa fa-check" aria-hidden="true"></i> 
						        <?php else: ?>
											<i class="fa fa-times" aria-hidden="true"></i>
						        <?php endif; ?>
					        </td></tr>
					        <tr><td><b>Перевод закончен: </b></td><td> 
					        	<?php if ($model['translation']->is_finished): ?>
						        	<i class="fa fa-check" aria-hidden="true"></i> 
						        <?php else: ?>
											<i class="fa fa-times" aria-hidden="true"></i>
						        <?php endif; ?>
					        </td></tr>
							  </table>
							</div>
							<br>
							<a class="btn btn-default btn-md" href="/profile/feed">Назад</a>&nbsp;

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

				</div>
			</div>
		</div>
	</div>
</div>
